using SocialNetwork.BLL.Models;

namespace SocialNetwrok.PLL.Views;

public class UserOutcomingMessageView   //UserOutgoingMessageView
{
    public void Show(IEnumerable<Message> outcomingMessages)
    {
        Console.WriteLine("Исходящие сообщения");

        if (outcomingMessages.Count() == 0)
        {
            Console.WriteLine("Исходящих сообщений нет");
            return;
        }

        outcomingMessages.ToList().ForEach(message =>
        {
            Console.WriteLine("Кому: {0}. Текст сообщения: {1}", message.RecipientEmail, message.Content);
        });
    }
}
