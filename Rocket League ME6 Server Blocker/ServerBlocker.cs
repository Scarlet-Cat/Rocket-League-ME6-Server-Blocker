using NetFwTypeLib;

namespace Rocket_League_ME6_Server_Blocker
{
    internal class ServerBlocker
    {
        private static string ruleName = "Rocket League ME6 Block";
        private static string ruleDescription = "Block ME6 server because of its location and high ping";
        private static string ipAddresses = "34.164.0.0-34.164.255.255," +
                                            "34.165.0.0-34.165.255.255," +
                                            "35.252.0.0-35.252.255.255";
        private static int ruleProfile = (int)NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_ALL;
        private static string rocketLeagueEXEPath = String.Empty;
        private static string rocketLeagueEXEName = "RocketLeague.exe";
        private static INetFwPolicy2 firewallPolicy;
        public ServerBlocker()
        {
            Type policyType = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(policyType);
        }

        public static void createRules()
        {
            Type ruleType = Type.GetTypeFromProgID("HNetCfg.FWRule");
            INetFwRule3 firewallRuleInBound = (INetFwRule3)Activator.CreateInstance(ruleType);
            firewallRuleInBound.Name = ruleName;
            firewallRuleInBound.Description = ruleDescription;
            firewallRuleInBound.RemoteAddresses = ipAddresses;
            firewallRuleInBound.Profiles = ruleProfile;
            firewallRuleInBound.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
            firewallRuleInBound.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
            if (!rocketLeagueEXEPath.Equals(String.Empty))
            {
                firewallRuleInBound.ApplicationName = rocketLeagueEXEPath;
            }

            INetFwRule3 firewallRuleOutBound = (INetFwRule3)Activator.CreateInstance(ruleType);
            firewallRuleOutBound.Name = ruleName;
            firewallRuleOutBound.Description = ruleDescription;
            firewallRuleOutBound.RemoteAddresses = ipAddresses;
            firewallRuleOutBound.Profiles = ruleProfile;
            firewallRuleOutBound.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
            firewallRuleOutBound.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
            if (!rocketLeagueEXEPath.Equals(String.Empty))
            {
                firewallRuleOutBound.ApplicationName = rocketLeagueEXEPath;
            }

            firewallPolicy.Rules.Add(firewallRuleInBound);
            firewallPolicy.Rules.Add(firewallRuleOutBound);
        }

        public static void resetRules()
        {
            firewallPolicy?.Rules.Remove(ruleName);
            createRules();
        }
        public static bool isRulesExist()
        {
            return isRulesExist(ruleName);
        }
        private static bool isRulesExist(string ruleName)
        {
            int numberOfRules = 0;
            foreach (INetFwRule rule in firewallPolicy.Rules)
            {
                if (rule.Name == ruleName)
                {
                    numberOfRules++;
                }
            }
            return numberOfRules != 0;
        }
        public static void toggleRules(bool state)
        {
            toggleRules(ruleName, state);
        }
        private static void toggleRules(string ruleName, bool state)
        {
            foreach (INetFwRule rule in firewallPolicy.Rules)
            {
                if (rule.Name == ruleName)
                {
                    rule.Enabled = state;
                }
            }
        }
        public static void deleteRules()
        {
            deleteRules(ruleName);
        }
        private static void deleteRules(string ruleName)
        {
            foreach (INetFwRule rule in firewallPolicy.Rules)
            {
                if (rule.Name == ruleName)
                {
                    firewallPolicy.Rules.Remove(ruleName);
                }
            }
        }

        public static void toggleAffectRocketLeagueOnly(bool toggle)
        {
            foreach (INetFwRule rule in firewallPolicy.Rules)
            {
                if (rule.Name == ruleName)
                {
                    if (!rocketLeagueEXEPath.Equals(String.Empty))
                    {
                        rule.ApplicationName = toggle ? rocketLeagueEXEPath : null;
                    }
                }
            }
        }
        public static bool checkForCorrectEXE()
        {
            return checkForCorrectEXE(rocketLeagueEXEPath);
        }
        public static bool checkForCorrectEXE(string path)
        {
            if (!Path.GetFileName(path).Equals(rocketLeagueEXEName))
            {
                MessageBox.Show("wrong Rocket League exe (targeting Rocket League exe only won't work)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public static void setPath(string path)
        {
            rocketLeagueEXEPath = path;
        }
        public static void resetPathToDefault()
        {
            setPath(String.Empty);
        }
        public static string getPath()
        {
            return rocketLeagueEXEPath;
        }

    }
}
