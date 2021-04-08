using System.Collections;
using System.Collections.Generic;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class Clients
{
    //보낼 데이터
    //2번째(위치 = 1번째) 배열부터 보낼데이터 담기
    //1번쨰는 sendFormCode가 들어감
    private byte[] buf;


    //테스트용!
    private StringBuilder server_resp;
    public StringBuilder geta()
    {
        return server_resp;
    }

    //스레드 관리
    Thread clientThread;

    enum Purpose : byte
    {
        CHECKPW = 0b10000000,
    }

    Json_Maker jm;

    public Clients()
    {
        server_resp = new StringBuilder();

        jm = new Json_Maker();
    }
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

    //buf를 서버로 보낼 데이터
    //buf맨앞에 sendform 
    //뒤에 아이디 + 비밀번호
    //null은 buf에서 아이디와 비밀번호를 나누기 위한 수단

    //buf = Encoding.UTF8.GetBytes(null + Id_Input.text + null + PassWord_Input.text);

    //Enum의 SendFormCode중 보낼 형태
    //buf[0] = (byte) SendFormCode.LOGIN;
    //connect();

    //서버로부터 받은 파일 txt -> true면 로그인

    public bool sing_Up(string id, string pw, string email, string nickname)
    {
        //sql_builder.SIGNUP(id, pw, email, nickname);

        //null은 sendForm을 담을곳!
        buf = Encoding.UTF8.GetBytes('\0'+ jm.SIGNUP(id, pw, email, nickname));
        buf[0] = (byte)SendFormCode.SIGNUP;
        send();

        //test용
        return (server_resp.ToString() == "t") ? true : false ;
    }

    //purpose는 기본 true로!
    public bool login(string id, string pw, bool purpose)
    {
        //sql_builder.LOGIN(id);


        buf = Encoding.UTF8.GetBytes('\0'+ jm.LOGIN(id, pw, purpose));
        send();

        //성공여부에 따라 return
        return (server_resp.ToString() == "t") ? true : false;
    }
    public string find_id(string email)
    {
        //sql_builder.FINDID(email);


        buf = Encoding.UTF8.GetBytes('\0'+ jm.FINDID(email));
        
        send();

        //returns ID
        return server_resp.ToString();
    }
    public bool change_Id(string id, string new_id)
    {
        //sql_builder.FINDID(email);


        buf = Encoding.UTF8.GetBytes('\0'+ jm.CHANGEID(id, new_id));

        send();


        return (server_resp.ToString() == "t") ? true : false;
    }
    public bool change_Pw(string id, string pw, string new_Pw)
    {
        //sql_builder.FINDID(email);

        buf = Encoding.UTF8.GetBytes('\0'+ jm.CHANGEPW(id, pw, new_Pw));

        send();

        return (server_resp.ToString() == "t") ? true : false;
    }
    public bool delete_Account(string id, string pw)
    {
        //sql_builder.FINDID(email);

        buf = Encoding.UTF8.GetBytes('\0'+ jm.DELETEACCOUNT(id, pw));

        send();

        return (server_resp.ToString() == "t") ? true : false;
    }
    public string email_Vertify(string email)
    {
        //sql_builder.FINDID(email);

        buf = Encoding.UTF8.GetBytes('\0'+ jm.EMAILVERTIFY(email));

        send();

        return server_resp.ToString();
    }
    public bool id_Overlap(string id)
    {
        //sql_builder.FINDID(email);

        buf = Encoding.UTF8.GetBytes('\0'+ jm.IDOVERLAP(id));

        send();

        return (server_resp.ToString() == "t") ? true : false;
    }
    public bool nick_Overlap(string nickname)
    {
        //sql_builder.FINDID(email);

        buf = Encoding.UTF8.GetBytes('\0'+ jm.NICKOVERLAP(nickname));

        send();

        return (server_resp.ToString() == "t") ? true : false;
    }
    public bool email_Overlap(string email)
    {
        //sql_builder.FINDID(email);

        buf = Encoding.UTF8.GetBytes('\0'+ jm.EMAILOVERLAP(email));

        send();

        return (server_resp.ToString() == "t") ? true : false;
    }
    public bool is_Input_Correct(string nickname)
    {
        //sql_builder.FINDID(email);

        buf = Encoding.UTF8.GetBytes('\0'+ jm.NICKOVERLAP(nickname));

        send();

        return true;
    }

    /*
    public string find_Pw(string id)
    {
        sql_builder.FINDPW(id);

        buf = Encoding.UTF8.GetBytes(query.ToString());
        buf[0] = (byte)SendFormCode.SIGNUP;

        send();

        return txt;
    }

    //로그인 되어있는상태에서만
    public void change_Id(string pw, string id, string new_id)
    {
        sql_builder.CHANGEID(id, new_id);
        

        buf = Encoding.UTF8.GetBytes(query.ToString());
        buf[0] = (byte)SendFormCode.CHANGEID;

        send();
    }
    public bool change_Pw(string id, string pw, string new_pw)
    {
        if(!login(id, pw, false)) { return false; }

        sql_builder.CHANGEPW(id, new_pw);
        
        buf = Encoding.UTF8.GetBytes(query.ToString());
        buf[0] = (byte)SendFormCode.CHANGEPW;

        send();
        if (txt.Equals('s')) 
        { 
            return true; 
        }
        else 
        { 
            return false; 
        }
    }
    public bool delete_Account(string id, string pw)
    {
        sql_builder.DELETEACCOUNT(id, pw);
        
        buf = Encoding.UTF8.GetBytes(query.ToString());
        buf[0] = (byte)SendFormCode.DELETEACCOUNT;

        send();

        if (txt.Equals('s')) 
        { 
            return true; 
        }
        else 
        { 
            return false; 
        }
    }

    //이메일로 6자리 숫자를 보내고
    //클라이언트로 6자를 숫자를 보낸다.
    public string email_Vertify(string email)
    {
        sql_builder.EMAILVERTIFY(email);
        

        buf = Encoding.UTF8.GetBytes(query.ToString());
        buf[0] = (byte)SendFormCode.DELETEACCOUNT;

        send();

        return txt;
    }
    */

    private void send()
    {
        clientThread = new Thread(clientFunc);
        clientThread.IsBackground = true;
        clientThread.Start();
        clientThread.Join();
    }



    //==========수정금지==========
    private void clientFunc(object obj)
    {
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPAddress ip_ad = IPAddress.Parse("20.194.44.146");
        EndPoint serverEP = new IPEndPoint(ip_ad, 11200);
        socket.Connect(serverEP);

        //string jsonData = ObjectToJson(보낼꺼);
        //socket.Send(jsonData);
        socket.Send(buf);

        //받는데이터
        //recvBytes에 최종으로 받은 데이터가 저장된다.
        byte[] recvBytes = new byte[1024];

        int nRecv = socket.Receive(recvBytes);
        //string txt = "" + recvBytes[0] + recvBytes[1];



        server_resp.Append(Encoding.UTF8.GetString(recvBytes, 0, nRecv));

        socket.Close();
    }
    //==========수정금지==========
}
