namespace Acedrive.Domain
{
  public class SessionHandler
  {
    private static Session _instance { get; set; }
    public static Session Instance()
    {
      if (_instance is null)
      {
        _instance = new Session();
      }
      return _instance;
    }
  }
  public class Session
  {
    internal Session()
    {

    }


  }
}