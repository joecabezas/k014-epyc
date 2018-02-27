public class PlayerData {

    private int connectionId;
    private string name;

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public int ConnectionId
    {
        get
        {
            return connectionId;
        }

        set
        {
            connectionId = value;
        }
    }

    public override string ToString()
    {
        return string.Format("(connId:{0}, name:{1})", connectionId, name);
    }
}
