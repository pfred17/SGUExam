// BLL/EmailService.cs
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

public class EmailService
{
    private string fromEmail = "baop00905@gmail.com";
    private string appPassword = "fhhn tdvp bvly xnpk";

    public void SendVerificationCode(string toEmail, string code)
    {
        var msg = new MimeMessage();
        msg.From.Add(MailboxAddress.Parse(fromEmail));
        msg.To.Add(MailboxAddress.Parse(toEmail));
        msg.Subject = "Mã xác thực";
        msg.Body = new TextPart("plain") { Text = $"Mã xác thực của bạn: {code}" };

        using var client = new SmtpClient();
        client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
        client.Authenticate(fromEmail, appPassword);
        client.Send(msg);
        client.Disconnect(true);
    }
}
