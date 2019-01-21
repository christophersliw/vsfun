using System;
using System.Collections.Generic;
using System.Linq;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit.Security;

namespace mailkit
{
   
    public static class FolderNames
    {
        public static string Odbiorcza => "odbiorcza";
        public static string Wychodzace => "wychodzace";
        public static string Wyslane => "wyslane";
        public static string Robocze => "robocze";
        public static string Archiwum => "archiwum";
        public static string Usuniete => "kosz";
    }
    internal class Program
    {
        protected static Dictionary<string, IList<string>> _commonFolderNames;      

        public static void Main(string[] args)
        {
            _commonFolderNames = new Dictionary<string, IList<string>>();
            _commonFolderNames.Add(FolderNames.Odbiorcza, new List<string> { "inbox", "[inbox]", "odbiorcza" });
            _commonFolderNames.Add(FolderNames.Wyslane, new List<string> { "sent", "[gmail]/wysłane", "wysłane", "elementy wysłane" });
            _commonFolderNames.Add(FolderNames.Archiwum, new List<string> { "archiwum", "archive" });
            _commonFolderNames.Add(FolderNames.Usuniete, new List<string> { "kosz", "[gmail]/kosz", "deleted", "elementy usunięte" });
            _commonFolderNames.Add(FolderNames.Robocze, new List<string> { "robocze", "[gmail]/wersje robocze", "drafts", "wersje robocze" });
            _commonFolderNames.Add(FolderNames.Wychodzace, new List<string> { "wychodzące", "outbox", "skrzynka nadawcza" });
            
            using (var client = new ImapClient())
            {
                client.Connect("mail.assecods.pl", 993, SecureSocketOptions.SslOnConnect);

                client.Authenticate("rekrutacjatest@assecods.pl", "AV9MJ7F3M7bK11");

//                client.Connect ("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);
//
//               client.Authenticate ("janwysylajacy01@gmail.com", "Tester1234!@#");
                
             var s =    GetFolder("archiwum",  client);



                client.Inbox.Open(FolderAccess.ReadOnly);

                var uids = client.Inbox.Search(SearchQuery.All);

                foreach (var uid in uids)
                {
                    var message = client.Inbox.GetMessage(uid);

                    // write the message to a file
                    message.WriteTo(string.Format("{0}.eml", uid));

                    Console.WriteLine(message.Subject);
                }

                var personal = client.GetFolder(client.PersonalNamespaces[0]);

                var f = personal.GetSubfolder("Elementy wysłane");
                f.Open(FolderAccess.ReadOnly);
                var Ids = f.Search(SearchQuery.All);
                f.Open(FolderAccess.ReadOnly);

                foreach (var id in Ids)
                {
                    var m = f.GetMessage(id);

                    Console.WriteLine(String.Format("sId: {0}, id:{1}, s: {2}", id, m.MessageId, m.Subject));
                }


                foreach (var folder in personal.GetSubfolders(false))
                {
                    Console.WriteLine(folder.Name);

                    if (folder.Name == "[Gmail]")
                    {
                        foreach (var infolder in folder.GetSubfolders(false))
                        {
                            Console.WriteLine("gmail:" + infolder.Name);
                        }
                    }

                    if (folder.Name == "elementy wysłane" || folder.Name == "archiwum" || folder.Name == "inbox")
                    {
                        folder.Open(FolderAccess.ReadOnly);
                        var sIds = folder.Search(SearchQuery.All);
                        folder.Open(FolderAccess.ReadOnly);

                        foreach (var id in sIds)
                        {
                            var m = folder.GetMessage(id);

                            Console.WriteLine(String.Format("sId: {0}, id:{1}, s: {2}", id, m.MessageId, m.Subject));
                        }
                    }
                }

                client.Disconnect(true);
            }

            Console.ReadKey();
        }
        
        public static IMailFolder GetFolder(string folderName, ImapClient _imapClient)
        {
            return GetFolder(folderName, _imapClient.GetFolders(_imapClient.PersonalNamespaces[0]));
        }
        
        protected static IMailFolder GetFolder(string folderName, IEnumerable<IMailFolder> folders)
        {
            IMailFolder result = null;

            foreach (var subfolder in folders)
            {
                foreach (var name in  _commonFolderNames[folderName])
                {
                    if (subfolder.Name.ToLower() == name.ToLower())
                    {
                        result =  subfolder;
                    }
                }

                if (result == null && subfolder.GetSubfolders() != null && subfolder.GetSubfolders().Any())
                {
                    result = GetFolder(folderName, subfolder.GetSubfolders());
                }
            }

            return result;
        }
    }
}