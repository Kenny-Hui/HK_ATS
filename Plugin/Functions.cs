using OpenBveApi.Runtime;

namespace Plugin {
    internal static class Func {
        internal static int GetDigit(int number, int digit) {
            return (number / (int)System.Math.Pow(10, digit - 1)) % 10;
        }

        internal static int Keys(string keyname) {
            switch (keyname) {
                case "key2":
                    return 2;
                case "key3":
                    return 3;
                case "key4":
                    return 4;
                case "key5":
                    return 5;
                case "key6":
                    return 6;
                case "key7":
                    return 7;
                case "key8":
                    return 8;
                case "key9":
                    return 9;
                case "key0":
                    return 0;
                case "keyspace":
                    return 10;
                case "keywiperup":
                    return 15;
                case "keywiperdown":
                    return 16;
                case "keymainbreaker":
                    return 17;
                case "keyraisepan":
                    return 18;
                case "keylowerpan":
                    return 19;
                case "keylivesteaminjector":
                    return 20;
                case "keyrightdoor":
                    return 21;
                case "keyleftdoor":
                    return 22;
                case "keygearup":
                    return 23;
                case "keygeardown":
                    return 24;
                case "keyfillfuel":
                    return 25;
                case "keydecreasecutoff":
                    return 26;
                case "keyincreasecutoff":
                    return 27;
                case "keysteaminjector":
                    return 28;
                case "keyblowers":
                    return 29;
                case "keyenginestop":
                    return 30;
                case "keyenginestart":
                    return 31;
                case "keypgup":
                    return 32;
                case "keypgdn":
                    return 33;
                case "keyend":
                    return 34;
                case "keyhome":
                    return 35;
                case "keydel":
                    return 36;
                case "keyins":
                    return 37;
                default:
                    return 1;
            }
        }

    }
}
