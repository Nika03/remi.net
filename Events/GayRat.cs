public class Gifs
{
    public static void Almic()
    {
        string[] rats = new string[] { 
            "https://tenor.com/view/whygena-reggie-gif-20262381",
            "https://imgur.com/a/c9AyI5a",
            "https://media.discordapp.net/attachments/665624930599174154/986280946166796378/B6A6A6F6-0940-4AA0-83EB-B0E0C046180C-1.gif",
            "https://tenor.com/view/whygena-whygena-tentacles-reggie-reggie-the-rat-cute-rat-boy-gif-24174715",
            "https://tenor.com/view/reggie-mouse-trap-gif-25221480",               
            "https://media.discordapp.net/attachments/473197954132475907/987137675960131614/FDXskHtVQAMsNM_.gif",
            "https://tenor.com/view/meme-reggie-the-rat-berserk-skeleton-gif-25594200",
            "https://tenor.com/view/dansen-whygena-reggie-gif-21008024",
            "https://tenor.com/view/almic-gif-19160345"
        };

        Random rnd = new Random();
        int shuffle = rnd.Next(rats.GetLength(0));
        //chooses a random number between the array length, starting at 0 (arrays start index at 0) and ending at [array length] - 1

        string dizzy = rats[shuffle];
        //random gif from the array

        Console.WriteLine("Current array length is " + rats.GetLength(0));
        Console.WriteLine("Shuffle is " + shuffle);
        Console.WriteLine("Array value sellected by 'shuffle' >> " + dizzy);
    }
}

