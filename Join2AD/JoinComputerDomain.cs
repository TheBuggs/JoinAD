using System;
using System.Management;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Join2AD
{
    class JoinComputerDomain
    {
        // Group of constans. I don't use in this class
        const int JOIN_DOMAIN = 1;
        const int ACCT_CREATE = 2;
        const int ACCT_DELETE = 4;
        const int WIN9X_UPGRADE = 16;
        const int DOMAIN_JOIN_IF_JOINED = 32;
        const int JOIN_UNSECURE = 64;
        const int MACHINE_PASSWORD_PASSED = 128;
        const int DEFERRED_SPN_SET = 256;
        const int INSTALL_INVOCATION = 262144;

        public JoinComputerDomain(string name = "", string domain = "", string password = "", string username = "", string ou = "") {
            this.domain = domain;
            this.password = password;
            this.username = username;
            this.ou = ou;
            this.name = name;
        }

        public string domain { get; set; }
        public string password { get; set; }
        public string username { get; set; }
        public string ou { get; set; }
        public string name { get; set; }

        public bool JoinAndSetName(Http req)
        {
            // Get WMI object for this machine
            using (ManagementObject computerSystem = new ManagementObject("Win32_ComputerSystem.Name='" + Environment.MachineName + "'"))
            {
                // Flag check for errors
                int result = -1;

                try
                {
                    // JOIN_DOMAIN + ACCT_CREATE is a magic number where is equal 3, 
                    // that is mean join to domain and create computer account
                    int parameters = 3; 

                    object[] methodArgs = { this.domain, this.password, this.username + "@" + this.domain, this.ou, parameters };

                    computerSystem.Scope.Options.Authentication = AuthenticationLevel.PacketPrivacy;
                    computerSystem.Scope.Options.Impersonation = ImpersonationLevel.Impersonate;
                    computerSystem.Scope.Options.EnablePrivileges = true;

                    object joinParams = computerSystem.InvokeMethod("JoinDomainOrWorkgroup", methodArgs);

                    result = (int)Convert.ToInt32(joinParams);
                }
                catch (Exception e) 
                {
                    MessageBox.Show("Join to domain is failed!\n" + e.ToString());
                    return false;
                }

                if (result != 0) {

                    string strErrorDescription = "Undefined " + result.ToString();

                    switch (result)
                    {
                        case 5:
                            // Access is denied
                            strErrorDescription = "Достъпът е отказан";
                            break;
                        case 87:
                            // The parameter is incorrect
                            strErrorDescription = "Има неправилен параметър";
                            break;
                        case 110:
                            // Unable to update the password
                            strErrorDescription = "Системата не може да отвори посочения обект";
                            break;
                        case 1323:
                            strErrorDescription = "Необходимо да е обновите паролата си"; 
                            break;
                        case 1326:
                            // Logon failure: unknown username or bad password
                            strErrorDescription = "Грешни данни за: непознато име или парола";
                            break;
                        case 1355:
                            // The specified domain either does not exist or could not be contacted
                            strErrorDescription = "Този домейн не съществува или не е видим"; 
                            break;
                        case 2224:
                            // The account already exists
                            strErrorDescription = "Този акаунт вече съществува"; 
                            break;
                        case 2691:
                            // The machine is already joined to the domain
                            strErrorDescription = "Машината вече е добавена в домейна"; 
                            break;
                        case 2692:
                            // The machine is not currently joined to a domain
                            strErrorDescription = "Понастоящем машината не е присъединена към домейнa";
                            break;
                    }
                    
                    bool hasHttpError = false;
                    try
                    {
                        // Send data to your API
                        if (req != null)
                        {
                            req.sendFinalJSON();
                        }
                    }
                    catch (Exception ex){ hasHttpError = true; }

                    if (hasHttpError) {
                        strErrorDescription += "\nСъщо така не можа да бъде отразена информация в DB за неуспрешното присъединяване на устройството към домейна";
                    }

                    MessageBox.Show(strErrorDescription, "Грешка",
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Exclamation);
                    // Join the computer to the domain failed
                    return false;
                }

                if ((Environment.MachineName).ToString().ToUpper() != this.name)
                {
                    // Join to domain was successful and now must be to renamed
                    ManagementBaseObject inputArgs = computerSystem.GetMethodParameters("Rename");

                    inputArgs["Name"] = this.name;
                    inputArgs["Password"] = this.password;
                    inputArgs["UserName"] = this.username + "@" + this.domain;

                    // Set the new name
                    ManagementBaseObject nameParams = computerSystem.InvokeMethod("Rename", inputArgs, null);

                    if ((uint)(nameParams.Properties["ReturnValue"].Value) != 0)
                    {
                        // Рenaming the computer failed
                        MessageBox.Show("Преименуването на компютъра е неуспешно!\n");
                        return false;
                    }
                }
                // Рenaming the computer was successful
                return true;
            }
        }
    }
}
