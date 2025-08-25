using System;

public class SmtpEmailSender : IEmailSender
{
    public readonly int Value;
    public SmtpEmailSender()
    {
        Value = new Random().Next(100);
        Console.WriteLine($"SmtpEmailSender creado {Value}");
    }

    public void SendEmail(string to, string subject, string body)
    {
        Console.WriteLine($"Enviando correo a {to}: {subject}\n{body}");
    }
}
