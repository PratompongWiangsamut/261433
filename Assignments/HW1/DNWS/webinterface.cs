using System;
using System.Collections.Generic;
using System.Text;

namespace DNWS
{
  class webinterface : IPlugin
  {
    protected static Dictionary<String, int> statDictionary = null;
    public  webinterface()
    {
      
    }

    public void PreProcessing(HTTPRequest request)
    {
       throw new NotImplementedException();
    }
    public HTTPResponse GetResponse(HTTPRequest request)
    {
      HTTPResponse response = null;
      StringBuilder sb = new StringBuilder();
            string[] ipandport=request.getPropertyByKey("RemoteEndPoint").Split(':');//My friend 600611030 advise me to do this and told me to see in this web https://en.wikipedia.org/wiki/List_of_HTTP_header_fields
      sb.Append("<html><body>Client IP : "+ipandport[0]);
      sb.Append("<br>Port : "+ipandport[1]);
      sb.Append("<br>Browser : "+request.getPropertyByKey("User-Agent"));
      sb.Append("<br>Accept Language :"+request.getPropertyByKey("Accept-Language"));
      sb.Append("<br>Accept Encoding : "+request.getPropertyByKey("Accept-Encoding"));
    
      sb.Append("</body></html>");
      response = new HTTPResponse(200);
      response.body = Encoding.UTF8.GetBytes(sb.ToString());
      return response;
    }

    public HTTPResponse PostProcessing(HTTPResponse response)
    {
      throw new NotImplementedException();
    }
  }
}