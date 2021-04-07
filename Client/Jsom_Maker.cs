using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

public class Json_Maker
{
    enum SendFormCode
    {
        SIGNUP = 1,
        LOGIN = 2,
        FINDID = 3,
        CHANGEID = 4,
        CHANGEPW = 5,
        DELETEACCOUNT = 6,
        EMAILVERTIFY = 7,
        IDOVERLAP = 8,
        NICKOVERLAP = 9,
        EMAILOVERLAP = 10,
        ISINPUTCORRECT = 11,
    }
    [Serializable]
    private class SIGNUP_J
    {
        public byte fn;
        public string id;
        public string pw;
        public string email;
        public string nickname;

        public SIGNUP_J(byte _function, string _id, string _pw, string _email, string _nickname)
        {
            this.fn = _function;
            this.id = _id;
            this.pw = _pw;
            this.email = _email;
            this.nickname = _nickname;
        }
    }
    public string SIGNUP(string _id, string _pw, string _email, string _nickname)
    {
        SIGNUP_J sign_Up = new SIGNUP_J((byte)SendFormCode.SIGNUP, _id, _pw, _email, _nickname);
        return JsonConvert.SerializeObject(sign_Up);
    }

    [Serializable]
    private class LOGIN_J
    {
        public byte fn;
        public string id;
        public string pw;
        public bool purpose;

        public LOGIN_J(byte _function, string _id, string _pw, bool _purpose)
        {
            this.fn = _function;
            this.id = _id;
            this.pw = _pw;
            this.purpose = _purpose;
        }
    }
    public string LOGIN(string _id, string _pw, bool _purpose)
    {
        LOGIN_J login = new LOGIN_J((byte)SendFormCode.SIGNUP, _id, _pw, _purpose);
        return JsonConvert.SerializeObject(login);
    }

    [Serializable]
    private class FINDID_J
    {
        public byte fn;
        public string email;

        public FINDID_J(byte _function, string _email)
        {
            this.fn = _function;
            this.email = _email;
        }
    }
    public string FINDID(string _email)//id?
    {
        FINDID_J find_Id = new FINDID_J((byte)SendFormCode.SIGNUP, _email);
        return JsonConvert.SerializeObject(find_Id);
    }

    [Serializable]
    private class CHANGEID_J
    {
        public byte fn;
        public string id;
        public string new_id;

        public CHANGEID_J(byte _function, string _id, string _new_id)
        {
            this.fn = _function;
            this.id = _id;
            this.new_id = _new_id;
        }
    }
    public string CHANGEID(string _id, string _new_id)
    {
        CHANGEID_J change_Id = new CHANGEID_J((byte)SendFormCode.SIGNUP, _id, _new_id);
        return JsonConvert.SerializeObject(change_Id);
    }


    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    private class CHANGEPW_J
    {
        public byte fn;
        public string id;
        public string pw;
        public string new_Pw;

        public CHANGEPW_J(byte _function, string _id, string _pw, string _new_Pw)
        {
            this.fn = _function;
            this.id = _id;
            this.pw = _pw;
            this.new_Pw = _new_Pw;
        }
    }
    public string CHANGEPW(string _id, string _pw, string _new_Pw)
    {
        CHANGEPW_J change_Pw = new CHANGEPW_J((byte)SendFormCode.SIGNUP, _id, _pw, _new_Pw);
        return JsonConvert.SerializeObject(change_Pw);
    }


    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    private class DELETEACCOUNT_J
    {
        public byte fn;
        public string id;
        public string pw;

        public DELETEACCOUNT_J(byte fn, string _id, string _pw)
        {
            this.fn = fn;
            this.id = _id;
            this.pw = _pw;
        }
    }
    public string DELETEACCOUNT(string _id, string _pw)//chech pw
    {
        DELETEACCOUNT_J delete_Account = new DELETEACCOUNT_J((byte)SendFormCode.SIGNUP, _id, _pw);
        return JsonConvert.SerializeObject(delete_Account);
    }


    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    private class EMAILVERTIFY_J
    {
        public byte fn;
        public string email;

        public EMAILVERTIFY_J(byte _function, string _email)
        {
            this.fn = _function;
            this.email = _email;
        }
    }
    public string EMAILVERTIFY(string _email)
    {
        EMAILVERTIFY_J email_Vertify = new EMAILVERTIFY_J((byte)SendFormCode.SIGNUP, _email);
        return JsonConvert.SerializeObject(email_Vertify);
    }


    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    private class IDOVERLAP_J
    {
        public byte fn;
        public string id;

        public IDOVERLAP_J(byte _function, string _id)
        {
            this.fn = _function;
            this.id = _id;
        }
    }
    public string IDOVERLAP(string _id)
    {
        EMAILVERTIFY_J id_Overlap = new EMAILVERTIFY_J((byte)SendFormCode.SIGNUP, _id);
        return JsonConvert.SerializeObject(id_Overlap);
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    private class NICKOVERLAP_J
    {
        public byte fn;
        public string nickname;

        public NICKOVERLAP_J(byte _function, string _nickname)
        {
            this.fn = _function;
            this.nickname = _nickname;
        }
    }
    public string NICKOVERLAP(string _nickname)
    {
        EMAILVERTIFY_J nick_Overlap = new EMAILVERTIFY_J((byte)SendFormCode.SIGNUP, _nickname);
        return JsonConvert.SerializeObject(nick_Overlap);
    }


    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    private class EMAILOVERLAP_J
    {
        public byte fn;
        public string email;

        public EMAILOVERLAP_J(byte _function, string _email)
        {
            this.fn = _function;
            this.email = _email;
        }
    }
    public string EMAILOVERLAP(string _email)
    {
        EMAILOVERLAP_J nick_Overlap = new EMAILOVERLAP_J((byte)SendFormCode.SIGNUP, _email);
        return JsonConvert.SerializeObject(nick_Overlap);
    }

    [Serializable]
    private class ISINPUTCORRECT_J
    {
        public byte fn;
        public string email;

        public ISINPUTCORRECT_J(byte _function, string _input)
        {
            this.fn = _function;
            this.email = _input;
        }
    }
    public string ISINPUTCORRECT(string _input)
    {
        EMAILOVERLAP_J is_Input_Correct = new EMAILOVERLAP_J((byte)SendFormCode.SIGNUP, _input);
        return JsonConvert.SerializeObject(is_Input_Correct);
    }
}
