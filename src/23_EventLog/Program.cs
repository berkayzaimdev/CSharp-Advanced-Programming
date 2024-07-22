#region EventLog nedir?

/*
   * C#'ta EventLog, Windows tarafından sağlanan bir bileşendir ve uygulamaların çalışma zamanında Event Viewer'a log yazmak veya okumak için kullanılan bir sınıftır. (Olay Yöneticisi)
   * Bu yapı sayesinde sistemin durumu hakkında bilgi sağlayabilir, uygulamaları izleyebilir, hataları ayıklayabilir ve çeşitli loglamalar gerçekleştirebiliriz.
   * Bu sayede OS seviyesinde bir loglama yapabilir, geliştiriciyi veya kullanıcıyı bilgilendirebiliriz.
*/

#endregion

#region EventViewer nedir?

/*
   * Event Viewer, Windows'ta bulunan bir araçtır ve sistemin çalışmasıyla ilgili çeşitli olayların kaydedildiği bir arayüz sağlar. Bu olaylar sistemle ilgili bilgi, hata, uyarı ve diğer olayları içerebilir
   
   * Event Viewer, uygulamadaki belirli event'ları izlemek ve olayları tarih, zaman, kaynak ve kategori gibi farklı ölçütlerle filtrelemek için kullanılabilir.
   * Event Viewer, sistemde oluşan hata ve uyarıları tanımlamak ve nedenlerini analiz etmek için kullanılabilir.
   * Event Viewer, sistemin performansıyla ilgili olayları izlemek ve performansı optimize etmek amacıyla kullanılabilir.
   * Event Viewer, bilgisayarın güvenliğiyle ilgili olayları izlemek için kullanılabilir. Yetkisiz erişim girişimleri, güvenlik ihlalleri ve diğer güvenlik olayları hakkında bilgi sağlar.
*/

#endregion

using System.Diagnostics;

const string eventLogSource = "MyApplicationExample"; // önce source ismi belirliyoruz
string logName = "MyApplicationLog"; // sonra log mesajını seçiyoruz

if (!EventLog.SourceExists(eventLogSource)) // eğer yoksa, source oluşturuyoruz
{
    EventLog.CreateEventSource(eventLogSource, logName);
    Console.WriteLine("Event Log oluşturuldu: ", logName);
}

string logMessage = $"Event Log: {DateTime.UtcNow}";
Console.WriteLine(logMessage);
EventLog.WriteEntry(eventLogSource, logName, EventLogEntryType.Information); // source, source'a yazmak istediğimiz log mesajı ve mesaj tipi
Process.Start("eventvwr.exe");
