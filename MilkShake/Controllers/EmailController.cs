using Microsoft.AspNetCore.Mvc;
using MilkShake.Models;
using MilkShake.Repository;
using MilkShake.Services;
using MilkShake.UnitOfWork;
using System.Net.Mail;
using System.Net;

namespace MilkShake.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> SendEmailWithAttachment()
        {
            try
            {
                var emailAddress = Request.Form["emailAddress"];
                var pdfFile = Request.Form.Files["pdfFile"];

                if (pdfFile == null || pdfFile.Length == 0)
                {
                    return BadRequest("PDF file is required.");
                }

                if (string.IsNullOrEmpty(emailAddress))
                {
                    return BadRequest("Email address is required.");
                }

                using (var ms = new MemoryStream())
                {
                    // Copy the contents of the uploaded PDF file into a memory stream
                    await pdfFile.CopyToAsync(ms);
                    ms.Position = 0;

                    // Create an email message
                    var message = new MailMessage();
                    message.To.Add(emailAddress);
                    message.Subject = "Order Confirmation";
                    message.Body = "Please find your order confirmation attached.";

                    // Attach the PDF file to the email
                    message.Attachments.Add(new Attachment(ms, pdfFile.FileName, "application/pdf"));

                    // Configure SMTP client (replace with your SMTP server details)
                    var smtpClient = new SmtpClient("smtp.gmail.com")
                    {
                        Port = 587, // Use port 465 for SSL
                        Credentials = new NetworkCredential("s.duplessis9000@gmail.com", "password"),
                        EnableSsl = true, // Set to true for TLS/SSL
                    };


                    // Send the email
                    await smtpClient.SendMailAsync(message);

                    return Ok("Email sent successfully.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while sending the email: {ex.Message}");
            }
        }
    }
}