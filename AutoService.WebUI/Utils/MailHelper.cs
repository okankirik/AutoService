using AutoService.Entities;
using System.Net;
using System.Net.Mail;


namespace AutoService.WebUI.Utils;

public class MailHelper
{
    public static async Task SendMailAsync(Customer customer)
    {
        SmtpClient smtpClient = new SmtpClient("mail.siteadresi.com", 587);
        smtpClient.Credentials = new NetworkCredential("emailKullaniciadi","emailsifre");
        smtpClient.EnableSsl = false;
        MailMessage message = new MailMessage();
        message.From = new MailAddress("info@siteadi.com");
        message.To.Add("info@siteadi.com");
        message.Subject = "Siteden mesaj geldi";
        message.Body = $"Mail Bilgileri <hr/> Ad Soyad: {customer.Name} {customer.Surname} <hr/> İlgilendiği Araç Id: {customer.Id} <hr/> Email: {customer.Email} <hr/> Telefon: {customer.Phone} <hr/> Notlar: {customer.Notes}";
        message.IsBodyHtml = true;
        await smtpClient.SendMailAsync(message);
        smtpClient.Dispose();
    }
}
