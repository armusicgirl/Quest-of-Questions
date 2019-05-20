using System;
using System.Collections.Generic;
using System.Text;

namespace Quest_of_Questions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Quest Of Questions";
            bool win = false;
            bool lose = false;

            //PreGame Logic
            Random rnd = new Random();
            int GameNumber = rnd.Next(1, 11);

            int currentRoom = 1;
            
            string command = "";
            string Name = "";


            //Start Of Game Seen
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            string a = "Press Enter to Start:";
            Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.CursorTop);
            Console.WriteLine(a);
            Console.ResetColor();
            Console.ReadLine();

            Name = GetName();
            Console.WriteLine();
            Console.Write("                        ");



            //string commandString = Console.ReadLine().ToUpper();
            string[] charSeparators = new string[] { " ", ",", "." };

            RoomClass[] RoomClass = new RoomClass[335]; // N, E, S, W, U, D
            HelperClass[] helper = new HelperClass[50];

            List<ItemClass> roomItem = new List<ItemClass>();
            List<ItemClass> inventory = new List<ItemClass>();
            List<QandA> QA = new List<QandA>();


            if (GameNumber % 2 == 0)
            {
                RoomClass[1] = new RoomClass(true, false, false, 2, 0, 0, 0, 0, 0, "Forest: ", " Up for an Adventure? Head north to go inside the acient temple;~)");
                RoomClass[2] = new RoomClass(true, false, false, 5, 42, 1, 41, 0, 0, "Entrance: ", "The room is lit up by torches. This isn't so bad, Lets go get the Golden Blizing");
                RoomClass[41] = new RoomClass(true, false, false, 4, 2, 0, 0, 0, 0, "Hall: ", "Not much to see. Shall we keep going?");
                RoomClass[42] = new RoomClass(true, false, false, 3, 0, 0, 2, 0, 0, "Hall: ", "Not much to see. Shall we keep going?");
                RoomClass[3] = new RoomClass(true, false, false, 6, 0, 42, 5, 0, 0, "Room of Gold: ", "Looks like a treasure room. ");
                RoomClass[4] = new RoomClass(true, false, false, 7, 5, 41, 0, 0, 0, "Treasure Hall: ", "Looks like a room that could be filled with lots of gold. ");
                RoomClass[5] = new RoomClass(true, false, true, 9, 3, 2, 4, 0, 0, "Oberon's Room: ", "A little cozy room, three walls full of books. In the corner is a chair with a little stone statue that looks like it could be reading. Wouldn't it be nice if you could speak to such a wise looking statue.");
                RoomClass[6] = new RoomClass(true, false, false, 0, 0, 3, 0, 0, 0, "First Understanding: ", " ");
                RoomClass[7] = new RoomClass(true, false, false, 0, 0, 4, 8, 0, 0, "Second Knowing: ", "");
                RoomClass[8] = new RoomClass(true, false, false, 210, 7, 0, 0, 0, 0, "Art Gallary", "So many paintings along the walls, There is a circle of statues in the middle of the room curounding a fountain");
                RoomClass[9] = new RoomClass(true, true, false, 111, 112, 5, 110, 0, 0, " First Battle: ", "There is a beast in the middle of the room...");
                RoomClass[10] = new RoomClass(true, false, false, 11, 9, 0, 8, 0, 0, "Dining room: ", "A long wooden table with acient food spread on it, almost looks fresh enough to eat.");
                RoomClass[11] = new RoomClass(true, false, false, 14, 12, 9, 10, 0, 0, "Kitchen: ", "A clay oven, Stone Cook tops, knives, and a garden still growing where sun shines in from the celieng.");
                RoomClass[12] = new RoomClass(true, false, false, 11, 13, 0, 9, 0, 0, "Music Room:", "String, wind, and percussion instruments are skattered around the room");
                RoomClass[13] = new RoomClass(true, false, false, 0, 0, 0, 12, 0, 0, "Third Learning: ", "");
                RoomClass[14] = new RoomClass(true, false, false, 18, 17, 11, 15, 0, 0, "Treasure treasure", "Lots of round dusty objects are skattered on the floor.");
                RoomClass[15] = new RoomClass(true, false, false, 0, 14, 0, 16, 0, 0, "Throne Room: ", " Golden thrones are at the top of a tower of stairs looking down onto a great wide floor.");
                RoomClass[16] = new RoomClass(true, false, false, 19, 15, 0, 0, 0, 0, "Snake Trap: ", "A pit of snakes, they take all your money.");
                RoomClass[17] = new RoomClass(true, false, false, 0, 18, 240, 14, 0, 0, ";~)  ", "Hint hint, if you look for it");
                RoomClass[18] = new RoomClass(true, false, false, 21, 17, 14, 20, 0, 0, "Break Room", "What is it you need? Chances are we got it here.");
                RoomClass[19] = new RoomClass(true, false, false, 24, 0, 16, 0, 0, 0, "Bed Room", "A huge room with a bed that looks fun to jump on.");
                RoomClass[20] = new RoomClass(true, false, false, 224, 18, 0, 0, 0, 0, "Side Room:", "This side room has a bit of everything, from gold to ways to heal yourself.");
                RoomClass[21] = new RoomClass(true, false, true, 23, 22, 18, 0, 0, 0, "Argus's Room: ", "A dog is sitting in the center of the room. When you walk in his tail starts wagging, how cute. Make sure to tell him he's a good boy!");
                RoomClass[22] = new RoomClass(true, false, true, 0, 0, 0, 21, 0, 0, "Dark Wind: ", "Walking in gives you the chills as a gust of wind comes from no where! You see a shadow fly across the room then stand still. Wonder if it's friendly...");
                RoomClass[23] = new RoomClass(true, true, false, 125, 228, 21, 0, 0, 0, "Battle Grounds: ", "A giant bird is flying around. You take a step in and it shoots fire at you from its mouth. It looks like it's either you or him.");
                RoomClass[24] = new RoomClass(true, false, false, 0, 0, 20, 19, 0, 27, "Painted Hall", "The walls are full of hieroglyphs. They look importand, if only you had a book that you could /TRANSLATE WALLS USING BOOK/. ");
                RoomClass[25] = new RoomClass(true, true, true, 26, 0, 23, 0, 0, 0, "Fly High Room: ", "There is a big tree growing in an almost dark room. Little glissing balls of light fly around it throwing little nuts at you. You cant make out what they are till you see a light that looks like a little human with wings sitting at the base of the tree. ");
                RoomClass[26] = new RoomClass(false, false, false, -29, 0, 25, 0, 0, 0, "Balancing the Sides: ", "Walking in you see the only other door to the north. The door is bloked with a gate. Wtitten on the gate is a riddle for you to SOLVE ");
                RoomClass[27] = new RoomClass(false, false, false, -30, 0, -24, -31, 0, 0, "Rusing River: ", "The door closes behind you. Blocking the other doors fast flowing river. To lower the bridge or open your door it looks like there is a key pad looking for a word. try and read the Clue");
                RoomClass[28] = new RoomClass(true, false, false, 34, 0, 23, 0, 0, 0, "Empty Hall", " Just more paintings on the side of the walls");
                RoomClass[29] = new RoomClass(true, false, false, 0, 0, 26, 30, 0, 0, "Golden hall", "Beautiful golden walls, with some healing flowers growing on the sides.");
                RoomClass[30] = new RoomClass(true, false, false, 32, 29, 27, 0, 0, 0, "Armory", "A stone room with weapons hung on racks");
                RoomClass[31] = new RoomClass(true, false, false, 0, 27, 0, 32, 0, 0, "Clue:", "One big drawing is on the wall with an inscription at the bottom. You may want to take a better look at it.");
                RoomClass[32] = new RoomClass(true, true, false, 133, 0, 30, 31, 0, 0, "Bitter Sweet: ", "There is a beautiful young woman pacing back and forth. ");
                RoomClass[33] = new RoomClass(false, false, false, 0, 234, 32, 235, 0, 0, "Trophy Room: ", "A massive room and the only thing in it is a piller with the Golden Blizing on it trapped within a cage with a lock on the outside. Looks like one more riddle ");
                RoomClass[34] = new RoomClass(true, false, true, 0, 28, 0, 33, 0, 0, "All knowing: ", "A small girl sits in a little rocking chair reading a book, /Listen/ She says, /and hear of this place./");
                RoomClass[35] = new RoomClass(true, false, false, 0, 33, 0, 0, 0, 0, "Credits: ", "    ");
                RoomClass[40] = new RoomClass(true, false, false, 17, 0, 0, 0, 0, 0, "Story Of Time: ", "     ");

                RoomClass[3].roomItem.Add(new ItemClass(10, "GOLD", "Adds to your wealth", 5, 0, 0));
                RoomClass[10].roomItem.Add(new ItemClass(10, "GOLD", "Adds to your wealth", 2, 0, 0));
                RoomClass[14].roomItem.Add(new ItemClass(10, "GOLD", "Adds to your wealth", 5, 0, 0));
                RoomClass[15].roomItem.Add(new ItemClass(10, "GOLD", "Adds to your wealth", 5, 0, 0));
                RoomClass[18].roomItem.Add(new ItemClass(10, "GOLD", "Adds to your wealth", 5, 0, 0));
                RoomClass[25].roomItem.Add(new ItemClass(10, "GOLD", "Adds to your wealth", 5, 0, 0));
                RoomClass[29].roomItem.Add(new ItemClass(10, "GOLD", "Adds to your wealth", 5, 0, 0));

                RoomClass[2].roomItem.Add(new ItemClass(1, "TORCH", "Lights Up The Room", 0, 1, 3));
                RoomClass[2].roomItem.Add(new ItemClass(9, "AXE", "Good for cutting down monsters", 4, 5, 3));
                RoomClass[4].roomItem.Add(new ItemClass(10, "Mace", "Nothing like hammereing monsters to the ground", 4, 5, 3));
                RoomClass[5].roomItem.Add(new ItemClass(100, "BOOK", "a book that allows you to translate hints on the walls", 50, 75, 0));
                RoomClass[6].roomItem.Add(new ItemClass(20, "ARMOR", "Protects you in fights, increases health", 10, 30, 2));
                RoomClass[6].roomItem.Add(new ItemClass(7, "SLING", "Protects you in fights, increases health", 10, 30, 0));
                RoomClass[6].roomItem.Add(new ItemClass(8, "STONES", "Protects you in fights, increases health", 10, 30, 2));
                RoomClass[10].roomItem.Add(new ItemClass(2, "KNIFE", "Sharp And Pointy, great for chopping", 3, 10, 2));
                RoomClass[11].roomItem.Add(new ItemClass(2, "KNIFE", "Sharp And Pointy, great for chopping", 3, 10, 2));
                RoomClass[12].roomItem.Add(new ItemClass(99, "INSTRUMENT1", "Snake charmer: hypnotises snakes", 15, 3, 1));
                RoomClass[12].roomItem.Add(new ItemClass(98, "INSTRUMENT2", "Pettler Flute: Playing this weakens monsters", 15, 3, 1));
                RoomClass[12].roomItem.Add(new ItemClass(98, "INSTRUMENT3", "Harmonica: a fun little instrument", 3, 3, 1));
                RoomClass[14].roomItem.Add(new ItemClass(-22, "BALLS", "Probably worth a bit of money", 15, 5, 3));
                RoomClass[30].roomItem.Add(new ItemClass(3, "SWORD", "Weapon for a hero", 5, 10, 5));
                RoomClass[30].roomItem.Add(new ItemClass(4, "SPEARS", "Perfect at throwing at monsters", 3, 3, 3));
                RoomClass[30].roomItem.Add(new ItemClass(5, "BOW", "great for shooting arrows", 3, 40, 0));
                RoomClass[30].roomItem.Add(new ItemClass(6, "ARROWS", "Can be shot out of a bow", 3, 5, 3));
                RoomClass[30].roomItem.Add(new ItemClass(6, "ARROWS", "Can be shot out of a bow", 3, 5, 3));
                RoomClass[33].roomItem.Add(new ItemClass(-101, "BLIZING", "A Priceless artifact", 800, 0, 0));

                RoomClass[40].roomItem.Add(new ItemClass(7, "GUN", "Can Shoot Bullets", 1, 40, 1));
                RoomClass[40].roomItem.Add(new ItemClass(8, "BULLETS", "Can be shot out of a gun", 3, 5, 1));

                ////I provide light but I’m not a candle, I’m hot but I’m not a bonfire, I have rays but I’m not an aquarium, I’m a star but I’m not a celebrity, I rise in the morning but I’m not someone getting out of bed
                ////sun
                ///*I’m measured on a special type of scale but I don’t weigh anything
                //  I can’t be seen but I’m not the Invisible Man
                //  I can whistle but I have no mouth
                //  I can knock down trees but I’m not a lumberjack
                //  I help you fly a kite but I’m not a piece of string
                //  I blow but I’m not someone playing the trumpet*/
                ////wind
                /*This thing is usually green
                  But it’s not a plate of peas
                  On the flag of Canada
                  There’s a maple one of these */
                // Leaf
                ///*I’m sometimes fluffy but I’m not a bunny
                //I can be a mushroom but I’m not eaten
                //I can drop water on you but I’m not a shower
                //I’m in the sky but I’m not a bird
                //I can cover the sun but I’m not the moon*/
                ////Cloud
                ///*I’m spherical but I’m not a soccer ball
                //I can be full even though I haven’t eaten anything
                //I have craters but I’m not a volcano
                //I have a dark side but I’m not Darth Vader
                //I can be seen at night but I’m not a star
                //I affect tides but I’m not the wind
                //*/
                ////Moon
                /*I fall but I never get back up
                I’m unique but I’m not a fingerprint
                I’m sometimes part of a ball but I’m not leather
                If I get warm enough I go away but I’m not a winter wardrobe
                I’m sometimes part of a man but I don’t have any skin*/
                //Snow
                /*I fall but I don’t get hurt
                I pour but I’m not a jug
                I come before the word bow but I’m not hair
                I help plants grow but I’m not the sun
                I can make you wet but I’m not a bath*/
                //rain
                /*I have an eye but I can’t see
                I rotate but I’m not the earth
                I have a spout but I’m not a teapot
                I can destroy buildings but I’m not dynamite
                I’m in the Wizard Of Oz but I’m not a witch*/
                //Tornado
                /*I can be looked through but I’m not a window
                I have your eye pressed to me but I’m not a door peephole
                I’m often placed on a tripod but I’m not a camera
                I help you see things that are far away but I’m not a pair of binoculars
                I’m often pointed at the sky but I’m not a satellite dish*/
                // telescope
                /*I’m curved but I’m not a banana
                I’m mentioned in the first book of the Bible but I’m not a snake
                I’m colorful but I’m not a parrot
                I’m mentioned in a Wizard Of Oz song but I’m not a Yellow Brick Road
                I’m found near a leprechaun but I’m not a pot of gold*/
                //Rainbow
                /*I have a source but I’m not a journalist
                I have a delta but I’m not a Greek alphabet
                I have banks on both sides of me but I’m not surrounded by money
                I flow but I’m not a bloodstream
                I’m full of water but I’m not a fish tank*/
                //River
                RoomClass[5].helper[5] = new HelperClass(1, "Oberon: ", "Welcome, " + Name + ",  I am Oberon. Type the number associated with each question for me to answer.");
                RoomClass[5].helper[5].QA.Add(new QandA(1, "Where am I and how do I get the Blizing?", "Welcome to the Temple of the Sun, To get the blizing you just have to get to it alive."));
                RoomClass[5].helper[5].QA.Add(new QandA(2, "What challenges will I have to face?", " This temple has been lined with riddles, monsters, and traps garding the blizing. Of corse we all have some hidden shortcuts..."));
                RoomClass[5].helper[5].QA.Add(new QandA(3, "What if I get lost?", "Helpers are around the temple, If you can read hyroglyphs the walls will be helpful. There may or may not be a translation book around these few rooms."));
                RoomClass[5].helper[5].QA.Add(new QandA(4, "Riddles? ", "Riddle 1: I can cover the sun but I’m not the moon"));
                RoomClass[5].helper[5].QA.Add(new QandA(-5, "Fighting? ", "Shooting from a distance doesn't do much dammage but it reduces your risk for injury"));

                RoomClass[21].helper[21] = new HelperClass(2, "Argus: ", "Hi, " + Name + "!  I'm Argus. Can I be of any assistance?");
                RoomClass[21].helper[21].QA.Add(new QandA(1, "Riddle Help?", "Riddle 4: I’m a star but I’m not a celebrity"));
                RoomClass[21].helper[21].QA.Add(new QandA(2, "Fighting Help?", "Fighting with close range weapons do more dammage, but it's easier for a monster to attack you."));
                RoomClass[21].helper[21].QA.Add(new QandA(3, "Who's a good dog?", "I suppose you want me to spin around and wag my tail"));

                RoomClass[22].helper[22] = new HelperClass(3, "Anonymous: ", "Hello, " + Name + ", How can I assist you?");
                RoomClass[22].helper[22].QA.Add(new QandA(1, "Who are you?", "Was that a personal question? Who I am is no concern to you."));
                RoomClass[22].helper[22].QA.Add(new QandA(2, "How should I prepair for the next monster?", "Make sure you have weapons that can shoot as far as the sun"));
                RoomClass[22].helper[22].QA.Add(new QandA(3, "How many riddles are there?", " with four riddles, remember for number three: It flows but it is not a bloodstream "));
                RoomClass[22].helper[22].QA.Add(new QandA(-4, "Any more hints for riddle 3", " It is full of water but it isn't a fish tank "));

                RoomClass[25].helper[25] = new HelperClass(4, "Urisk : ", "Hey, " + Name + ",  I supose you are looking for the Blizing.");
                RoomClass[25].helper[25].QA.Add(new QandA(1, "What are your friends and can you tell them to knock it off with the berries??!", "We are Dryads, they are protecting their tree, but, Guys Stop it! *they stop*"));
                RoomClass[25].helper[25].QA.Add(new QandA(2, "Do you have any hints for future riddles?", " Let me see.. Riddle 2: It's found near a leprechaun but It is not a pot of gold"));
                RoomClass[25].helper[25].QA.Add(new QandA(3, "Any other hints for riddles?", " Let me see.. Riddle 4: It rises in the morning but It is not someone getting out of bed"));
                RoomClass[25].helper[25].QA.Add(new QandA(-4, "Why aren't you flying around having a good time? ", "My tree is no more, I have been saving energy to bring back the tree of the moon, when the sunny season is over."));

                RoomClass[9].monster[9] = new MonsterClass("Giant Ogre", "A large green/brown beast with piles of bones around it", 12, 2, true, true);
                RoomClass[23].monster[23] = new MonsterClass("Fire Beetle", "Flying above you is a beetle about the size of a large dog with a beautiful, iridescent green, armor-like shell that shimmers in the sun. Also it spits acid so best to keep your distance. ", 12, 4, true, false);
                RoomClass[32].monster[32] = new MonsterClass("Ice Woman", "Her hands look Cold as Ice and her hair is frozen over. You walk towards her and when you're close enough she hits you hard wih her frozen boots.", 20, 4, true, true);

                RoomClass[14].riddle.Add(new RiddleClass(14, 1, 5, "I’m sometimes fluffy but I’m not a bunny, I can be a mushroom but I’m not eaten, I can drop water on you but I’m not a shower, I’m in the sky but I’m not a bird", "CLOUD", false));
                RoomClass[26].riddle.Add(new RiddleClass(26, 2, 5, "I’m curved but I’m not a banana, I’m mentioned in the first book of the Bible but I’m not a snake, I’m colorful but I’m not a parrot, I’m mentioned in a Wizard Of Oz song but I’m not a Yellow Brick Road", "RAINBOW", false));
                RoomClass[27].riddle.Add(new RiddleClass(27, 3, 5, " I have a source but I’m not a journalist, I have a delta but I’m not a Greek alphabet, I have banks on both sides of me but I’m not surrounded by money", "RIVER", false));
                RoomClass[33].riddle.Add(new RiddleClass(33, 4, 5, "I provide light but I’m not a candle, I’m hot but I’m not a bonfire, I have rays but I’m not an aquarium", "SUN", false));
            }
            if (GameNumber % 2 != 0 && GameNumber >= 5)
            {
                RoomClass[1] = new RoomClass(true, false, false, 2, 0, 0, 0, 0, 0, "Forest: ", " Up for an Adventure? Head north to go inside the acient temple;~)");
                RoomClass[2] = new RoomClass(true, false, false, 5, 42, 1, 41, 0, 0, "Entrance: ", "The room is lit up by torches. This isn't so bad, Lets go get the Golden Blizing");
                RoomClass[41] = new RoomClass(true, false, false, 4, 2, 0, 0, 0, 0, "Hall: ", "Not much to see. Shall we keep going?");
                RoomClass[42] = new RoomClass(true, false, false, 3, 0, 0, 2, 0, 0, "Hall: ", "Not much to see. Shall we keep going?");
                RoomClass[3] = new RoomClass(true, false, false, 6, 0, 42, 5, 0, 0, "Room of Gold: ", "Looks like a treasure room. ");
                RoomClass[4] = new RoomClass(true, false, false, 7, 5, 41, 0, 0, 0, "Treasure Hall: ", "Looks like a room that could be filled with lots of gold. ");
                RoomClass[5] = new RoomClass(true, false, true, 9, 3, 2, 4, 0, 0, "Oberon's Room: ", "A little cozy room, three walls full of books. In the corner is a chair with a little stone statue that looks like it could be reading. Wouldn't it be nice if you could speak to such a wise looking statue.");
                RoomClass[6] = new RoomClass(true, false, false, 0, 0, 3, 0, 0, 0, "First Understanding: ", " ");
                RoomClass[7] = new RoomClass(true, false, false, 0, 0, 4, 8, 0, 0, "Second Knowing: ", "");
                RoomClass[8] = new RoomClass(true, false, false, 210, 7, 0, 0, 0, 0, "Art Gallary", "So many paintings along the walls, There is a circle of statues in the middle of the room curounding a fountain");
                RoomClass[9] = new RoomClass(true, true, false, 111, 136, 5, 110, 0, 0, " First Battle: ", "There is a beast in the middle of the room...");
                RoomClass[10] = new RoomClass(true, false, false, 11, 9, 241, 8, 0, 0, "Dining room: ", "A long wooden table with acient food spread on it, almost looks fresh enough to eat.");
                RoomClass[11] = new RoomClass(true, false, false, 14, 12, 9, 10, 0, 0, "Kitchen: ", "A clay oven, Stone Cook tops, knives, and a garden still growing where sun shines in from the celieng.");
                RoomClass[12] = new RoomClass(true, false, false, 0, 13, 36, 11, 0, 0, "Music Room:", "String, wind, and percussion instruments are skattered around the room");
                RoomClass[36] = new RoomClass(true, false, false, 12, 0, 0, 9, 0, 0, "Reflection Pool", "Water looks so clear kinda want to dive in");
                RoomClass[13] = new RoomClass(true, false, false, 0, 0, 0, 12, 0, 0, "Third Learning: ", "");
                RoomClass[14] = new RoomClass(false, false, false, -18, -17, 11, -15, 0, 0, "Treasure treasure", "Lots of round dusty objects are skattered on the floor. Along With A piller in the center of the room with a riddle on it for you to SOLVE before you can move on.");
                RoomClass[15] = new RoomClass(true, false, false, 0, 14, 0, 16, 0, 0, "Throne Room: ", " Golden thrones are at the top of a tower of stairs looking down onto a great wide floor.");
                RoomClass[16] = new RoomClass(true, false, false, 19, 15, 0, 0, 0, 0, "Snake Trap: ", "A pit of snakes, they take all your money.");
                RoomClass[17] = new RoomClass(true, false, false, 0, 18, 0, 14, 0, 0, ";~)  ", "Hint hint, if you look for it");
                RoomClass[18] = new RoomClass(true, false, false, 21, 17, 14, 20, 0, 0, "Break Room", "What is it you need? Chances are we got it here.");
                RoomClass[19] = new RoomClass(true, false, false, 224, 0, 16, 0, 0, 0, "Bed Room", "A huge room with a bed that looks fun to jump on.");
                RoomClass[20] = new RoomClass(true, false, false, 224, 18, 0, 0, 0, 0, "Side Room:", "This side room has a bit of everything, from gold to ways to heal yourself.");
                RoomClass[21] = new RoomClass(true, false, true, 23, 22, 18, 0, 0, 0, "Argus's Room: ", "A dog is sitting in the center of the room. When you walk in his tail starts wagging, how cute. Make sure to tell him he's a good boy!");
                RoomClass[22] = new RoomClass(true, false, true, 0, 0, 0, 21, 0, 0, "Dark Wind: ", "Walking in gives you the chills as a gust of wind comes from no where! You see a shadow fly across the room then stand still. Wonder if it's friendly...");
                RoomClass[23] = new RoomClass(true, true, false, 125, 228, 21, 0, 0, 0, "Battle Grounds: ", "A giant bird is flying around. You take a step in and it shoots fire at you from its mouth. It looks like it's either you or him.");
                RoomClass[24] = new RoomClass(true, false, false, 0, 0, 20, 19, 0, 27, "Painted Hall", "The walls are full of hieroglyphs. They look importand, if only you had a book that you could /TRANSLATE WALLS USING BOOK/. ");
                RoomClass[25] = new RoomClass(true, true, true, 26, 0, 23, 0, 0, 0, "Fly High Room: ", "There is a big tree growing in an almost dark room. Little glissing balls of light fly round it. You cant make out what they are till you see a light that looks like a little human with wings sitting at the ase of the tree. ");
                RoomClass[26] = new RoomClass(false, false, false, -29, 0, 25, 0, 0, 0, "Balancing the Sides: ", "Walking in you see the only other door to the north. The door is bloked with a gate. Wtitten on the gate is a message and a scale with a small yellow ball weighing down one side. ");
                RoomClass[27] = new RoomClass(false, false, false, -30, 0, -24, -31, 0, 0, "Rusing River: ", "The door closes behind you. Blocking the other doors fast flowing river. To lower the bridge or open your door it looks like there is a key pad looking for a word. try and read the Clue");
                RoomClass[28] = new RoomClass(true, false, false, 34, 0, 23, 0, 0, 0, "Empty Hall", " Just more paintings on the side of the walls");
                RoomClass[29] = new RoomClass(true, false, false, 0, 0, 26, 30, 0, 0, "Golden hall", "Beautiful golden walls, with some healing flowers growing on the sides.");
                RoomClass[30] = new RoomClass(true, false, false, 32, 29, 27, 0, 0, 0, "Armory", "A stone room with weapons hung on racks");
                RoomClass[31] = new RoomClass(true, false, false, 0, 27, 0, 32, 0, 0, "Clue:", "One big drawing is on the wall with an inscription at the bottom. You may want to take a better look at it.");
                RoomClass[32] = new RoomClass(true, true, false, 133, 0, 30, 31, 0, 0, "Bitter Sweet: ", "There is a beautiful young woman pacing back and forth. ");
                RoomClass[33] = new RoomClass(false, false, false, 0, 234, 32, 235, 0, 0, "Trophy Room: ", "A massive room and the only thing in it is a piller with the Golden Blizing on it trapped within a cage with a lock on the outside. Looks like one more riddle ");
                RoomClass[34] = new RoomClass(true, false, true, 0, 28, 0, 33, 0, 0, "All knowing: ", "A small girl sits in a little rocking chair reading a book, /Listen/ She says and hear of this place.");
                RoomClass[35] = new RoomClass(true, false, false, 0, 33, 0, 0, 0, 0, "Credits: ", "    ");
                RoomClass[41] = new RoomClass(true, false, false, 10, 0, 0, 0, 0, 0, "Grand Room: ", "Lots of golden furniture. Look that fruit looks as if it was just picked.");

                RoomClass[3].roomItem.Add(new ItemClass(10, "GOLD", "Adds to your wealth", 5, 0, 0));
                RoomClass[10].roomItem.Add(new ItemClass(10, "GOLD", "Adds to your wealth", 2, 0, 0));
                RoomClass[14].roomItem.Add(new ItemClass(10, "GOLD", "Adds to your wealth", 5, 0, 0));
                RoomClass[15].roomItem.Add(new ItemClass(10, "GOLD", "Adds to your wealth", 5, 0, 0));
                RoomClass[18].roomItem.Add(new ItemClass(10, "GOLD", "Adds to your wealth", 5, 0, 0));
                RoomClass[25].roomItem.Add(new ItemClass(10, "GOLD", "Adds to your wealth", 5, 0, 0));
                RoomClass[29].roomItem.Add(new ItemClass(10, "GOLD", "Adds to your wealth", 5, 0, 0));
                RoomClass[41].roomItem.Add(new ItemClass(10, "GOLD", "Adds to your wealth", 5, 0, 0));

                RoomClass[2].roomItem.Add(new ItemClass(1, "TORCH", "Lights Up The Room", 0, 1, 3));
                RoomClass[2].roomItem.Add(new ItemClass(9, "AXE", "Good for cutting down monsters", 4, 5, 3));
                RoomClass[4].roomItem.Add(new ItemClass(10, "Mace", "Nothing like hammereing monsters to the ground", 4, 5, 3));
                RoomClass[5].roomItem.Add(new ItemClass(100, "BOOK", "a book that allows you to translate hints on the walls", 50, 75, 0));
                RoomClass[6].roomItem.Add(new ItemClass(20, "ARMOR", "Protects you in fights, increases health", 10, 30, 2));
                RoomClass[6].roomItem.Add(new ItemClass(7, "SLING", "Protects you in fights, increases health", 10, 30, 0));
                RoomClass[6].roomItem.Add(new ItemClass(8, "STONES", "Protects you in fights, increases health", 10, 30, 2));
                RoomClass[10].roomItem.Add(new ItemClass(2, "KNIFE", "Sharp And Pointy, great for chopping", 3, 10, 2));
                RoomClass[11].roomItem.Add(new ItemClass(2, "KNIFE", "Sharp And Pointy, great for chopping", 3, 10, 2));
                RoomClass[12].roomItem.Add(new ItemClass(99, "INSTRUMENT1", "Snake charmer: hypnotises snakes", 15, 3, 1));
                RoomClass[12].roomItem.Add(new ItemClass(98, "INSTRUMENT2", "Pettler Flute: Playing this weakens monsters", 15, 3, 1));
                RoomClass[12].roomItem.Add(new ItemClass(98, "INSTRUMENT3", "Harmonica: a fun little instrument", 3, 3, 1));
                RoomClass[14].roomItem.Add(new ItemClass(-22, "BALLS", "Probably worth a bit of money", 15, 5, 3));
                RoomClass[30].roomItem.Add(new ItemClass(3, "SWORD", "Weapon for a hero", 5, 10, 5));
                RoomClass[30].roomItem.Add(new ItemClass(4, "SPEARS", "Perfect at throwing at monsters", 3, 3, 3));
                RoomClass[30].roomItem.Add(new ItemClass(5, "BOW", "great for shooting arrows", 3, 40, 0));
                RoomClass[30].roomItem.Add(new ItemClass(6, "ARROWS", "Can be shot out of a bow", 3, 5, 3));
                RoomClass[30].roomItem.Add(new ItemClass(6, "ARROWS", "Can be shot out of a bow", 3, 5, 3));
                RoomClass[33].roomItem.Add(new ItemClass(-101, "BLIZING", "A Priceless artifact", 800, 0, 0));

                RoomClass[5].helper[5] = new HelperClass(1, "Oberon: ", "Welcome, " + Name + ",  I am Oberon. Type the number associated with each question for me to answer.");
                RoomClass[5].helper[5].QA.Add(new QandA(1, "Where am I and how do I get the Blizing?", "Welcome to the Temple of the Moon, To get the blizing you just have to get to it alive."));
                RoomClass[5].helper[5].QA.Add(new QandA(2, "What challenges will I have to face?", " This temple has been lined with riddles, monsters, and traps garding the blizing. Of corse we all have some hidden shortcuts..."));
                RoomClass[5].helper[5].QA.Add(new QandA(3, "What if I get lost?", "Helpers are around the temple, If you can read hyroglyphs the walls will be helpful. There may or may not be a translation book around these few rooms."));
                RoomClass[5].helper[5].QA.Add(new QandA(4, "Riddles? ", "Riddle 1: I’m often pointed at the sky but I’m not a satellite dish"));
                RoomClass[5].helper[5].QA.Add(new QandA(-5, "Fighting? ", "Shooting from a distance doesn't do much dammage but it reduces your risk for injury"));

                RoomClass[21].helper[21] = new HelperClass(2, "Argus: ", "Hi, " + Name + "!  I'm Argus. Can I be of any assistance?");
                RoomClass[21].helper[21].QA.Add(new QandA(1, "Riddle Help?", "Riddle 4: I’m a star but I’m not a celebrity"));
                RoomClass[21].helper[21].QA.Add(new QandA(2, "Fighting Help?", "Fighting with close range weapons do more dammage, but it's easier for a monster to attack you."));
                RoomClass[21].helper[21].QA.Add(new QandA(3, "Who's a good dog?", "I suppose you want me to spin around and wag my tail"));

                RoomClass[22].helper[22] = new HelperClass(3, "Anonymous: ", "Hello, " + Name + ", How can I assist you?");
                RoomClass[22].helper[22].QA.Add(new QandA(1, "Who are you?", "Was that a personal question? Who I am is no concern to you."));
                RoomClass[22].helper[22].QA.Add(new QandA(2, "How should I prepair for the next monster?", "Make sure you have weapons that can shoot as far as the sun"));
                RoomClass[22].helper[22].QA.Add(new QandA(3, "How many riddles are there?", " with four riddles, remember for number 3: It flows but it is not a bloodstream "));
                RoomClass[22].helper[22].QA.Add(new QandA(-4, "Any more hints for riddle 3", " It is full of water but it isn't a fish tank "));

                RoomClass[25].helper[25] = new HelperClass(4, "Urisk : ", "Hey, " + Name + ",  I supose you are looking for the Blizing.");
                RoomClass[25].helper[25].QA.Add(new QandA(1, "What are your friends and can you tell them to knock it off with the berries??!", "We are Dryads, they are protecting their tree, but, Guys Stop it! *they stop*"));
                RoomClass[25].helper[25].QA.Add(new QandA(2, "Do you have any hints for future riddles?", " Let me see.. Riddle 2: It blows but It isn't me playing the trumpet"));
                RoomClass[25].helper[25].QA.Add(new QandA(3, "Any other hints for riddles?", " Let me see.. Riddle 4: I affect tides but I’m not the wind"));
                RoomClass[25].helper[25].QA.Add(new QandA(-4, "Why aren't you flying around having a good time? ", "My tree is no more, I have been saving energy to bring back the tree of the sun, when the night season is over."));


                RoomClass[9].monster[9] = new MonsterClass("Temple Troll", "Smaller than its mountain cousin but still wielding a club with enough force to knock in an oak door, or your face.", 12, 2, true, true);
                RoomClass[23].monster[23] = new MonsterClass("Shadow Simurgh", " While majestic in flight these enormous birds are surrounded by shadowy flames that will burn you to death if you get too close. ", 12, 4, true, false);
                RoomClass[25].monster[25] = new MonsterClass("Dryads ", "Small balls of light swarming the giant tree in the center. T00 Small And Numorous To Fight, but the berries they are throwing at you are annoying. ", 10000, 0, true, false);
                RoomClass[32].monster[32] = new MonsterClass("Ice Woman", "Her hands look Cold as Ice and her hair is frozen over. You walk towards her and when you're close enough she hits you hard wih her frozen boots.", 20, 4, true, true);

                RoomClass[14].riddle.Add(new RiddleClass(14, 1, 5, "I can be looked through but I’m not a window, I have your eye pressed to me but I’m not a door peephole, I’m often placed on a tripod but I’m not a camera, I help you see things that are far away but I’m not a pair of binoculars", "TELESCOPE", false));
                RoomClass[26].riddle.Add(new RiddleClass(26, 2, 5, "I’m measured on a special type of scale but I don’t weigh anything, I can’t be seen but I’m not the Invisible Man, I can whistle but I have no mouth, I can knock down trees but I’m not a lumberjack ", "WIND", false));
                RoomClass[27].riddle.Add(new RiddleClass(27, 3, 5, " I have a source but I’m not a journalist, I have a delta but I’m not a Greek alphabet, I have banks on both sides of me but I’m not surrounded by money", "RIVER", false));
                RoomClass[33].riddle.Add(new RiddleClass(33, 4, 5, " I’m spherical but I’m not a soccer ball, I can be full even though I haven’t eaten anything, I have craters but I’m not a volcano, I have a dark side but I’m not Darth Vader", "MOON", false));

            }
            //only in games less than 5
            if (GameNumber % 2 != 0 && GameNumber < 5)
            {
                RoomClass[1] = new RoomClass(true, false, false, 2, 0, 0, 0, 0, 0, "Forest: ", " Up for an Adventure? Head north to go inside the acient temple;~)");
                RoomClass[2] = new RoomClass(true, false, false, 5, 41, 1, 42, 0, 0, "Entrance: ", "The room is lit up by torches. This isn't so bad, Lets go get the Golden Blizing");
                RoomClass[41] = new RoomClass(true, false, false, 4, 2, 0, 0, 0, 0, "Hall: ", "Not much to see. Shall we keep going?");
                RoomClass[42] = new RoomClass(true, false, false, 3, 0, 0, 2, 0, 0, "Hall: ", "Not much to see. Shall we keep going?");
                RoomClass[3] = new RoomClass(true, false, false, 6, 0, 42, 5, 0, 0, "Room of Gold: ", "Looks like a treasure room. ");
                RoomClass[4] = new RoomClass(true, false, false, 7, 5, 41, 0, 0, 0, "Treasure Hall: ", "Looks like a room that could be filled with lots of gold. ");
                RoomClass[5] = new RoomClass(true, false, true, 9, 3, 2, 4, 0, 0, "Oberon's Room: ", "A little cozy room, three walls full of books. In the corner is a chair with a little stone statue that looks like it could be reading. Wouldn't it be nice if you could speak to such a wise looking statue.");
                RoomClass[6] = new RoomClass(true, false, false, 0, 0, 3, 0, 0, 0, "First Understanding: ", " ");
                RoomClass[7] = new RoomClass(true, false, false, 0, 0, 4, 8, 0, 0, "Second Knowing: ", "");
                RoomClass[8] = new RoomClass(true, false, false, 210, 7, 0, 0, 0, 0, "Art Gallary", "So many paintings along the walls, There is a circle of statues in the middle of the room curounding a fountain");
                RoomClass[9] = new RoomClass(true, true, false, 111, 112, 5, 110, 0, 0, " First Battle: ", "There is a beast in the middle of the room...");
                RoomClass[10] = new RoomClass(true, false, false, 11, 9, 241, 8, 0, 0, "Dining room: ", "A long wooden table with acient food spread on it, almost looks fresh enough to eat.");
                RoomClass[11] = new RoomClass(true, false, false, 14, 12, 9, 10, 0, 0, "Kitchen: ", "A clay oven, Stone Cook tops, knives, and a garden still growing where sun shines in from the celieng.");
                RoomClass[12] = new RoomClass(true, false, false, 11, 13, 0, 9, 0, 0, "Music Room:", "String, wind, and percussion instruments are skattered around the room");
                RoomClass[13] = new RoomClass(true, false, false, 0, 0, 0, 12, 0, 0, "Third Learning: ", "");
                RoomClass[14] = new RoomClass(true, false, false, 18, 17, 11, 15, 0, 0, "Treasure treasure", "Lots of round dusty objects are skattered on the floor.");
                RoomClass[15] = new RoomClass(true, false, false, 0, 14, 0, 16, 0, 0, "Throne Room: ", " Golden thrones are at the top of a tower of stairs looking down onto a great wide floor.");
                RoomClass[16] = new RoomClass(true, false, false, 19, 15, 0, 0, 0, 0, "Snake Trap: ", "A pit of snakes, they take all your money.");
                RoomClass[17] = new RoomClass(true, false, false, 0, 18, 0, 14, 0, 0, ";~)  ", "Hint hint, if you look for it");
                RoomClass[18] = new RoomClass(true, false, false, 21, 17, 14, 20, 0, 0, "Break Room", "What is it you need? Chances are we got it here.");
                RoomClass[19] = new RoomClass(true, false, false, 224, 0, 16, 0, 0, 0, "Bed Room", "A huge room with a bed that looks fun to jump on.");
                RoomClass[20] = new RoomClass(true, false, false, 224, 18, 0, 0, 0, 0, "Side Room:", "This side room has a bit of everything, from gold to ways to heal yourself.");
                RoomClass[21] = new RoomClass(true, false, true, 23, 22, 18, 0, 0, 0, "Argus's Room: ", "A dog is sitting in the center of the room. When you walk in his tail starts wagging, how cute. Make sure to tell him he's a good boy!");
                RoomClass[22] = new RoomClass(true, false, true, 0, 0, 0, 21, 0, 0, "Dark Wind: ", "Walking in gives you the chills as a gust of wind comes from no where! You see a shadow fly across the room then stand still. Wonder if it's friendly...");
                RoomClass[23] = new RoomClass(true, true, false, 125, 223, 21, 0, 0, 0, "Battle Grounds: ", "A giant bird is flying around. You take a step in and it shoots fire at you from its mouth. It looks like it's either you or him.");
                RoomClass[24] = new RoomClass(true, false, false, 0, 0, 20, 19, 0, 27, "Painted Hall", "The walls are full of hieroglyphs. They look importand, if only you had a book that you could /TRANSLATE WALLS USING BOOK/. ");
                RoomClass[25] = new RoomClass(true, true, true, 26, 0, 23, 0, 0, 0, "Fly High Room: ", "There is a big tree growing in an almost dark room. Little glissing balls of light fly round it. You cant make out what they are till you see a light that looks like a little human with wings sitting at the base of the tree. ");
                RoomClass[26] = new RoomClass(true, false, false, -29, 0, 25, 0, 0, 0, "Balancing the Sides: ", "Walking in you see the only other door to the north. The door is bloked with a gate. Wtitten on the gate is a message and a scale with a small yellow ball weighing down one side. ");
                RoomClass[27] = new RoomClass(true, false, false, -30, 0, 24, -31, 0, 0, "Rusing River: ", "The door closes behind you. Blocking the other doors fast flowing river. To lower the bridge or open your door it looks like there is a key pad looking for a word. try and read the Clue");
                RoomClass[28] = new RoomClass(true, false, false, 234, 0, 23, 0, 0, 0, "Empty Hall", " Just more paintings on the side of the walls");
                RoomClass[29] = new RoomClass(true, false, false, 0, 0, 26, 30, 0, 0, "Golden hall", "Beautiful golden walls, with some healing flowers growing on the sides.");
                RoomClass[30] = new RoomClass(true, false, false, 32, 29, 27, 0, 0, 0, "Armory", "A stone room with weapons hung on racks");
                RoomClass[31] = new RoomClass(true, false, false, 0, 27, 0, 32, 0, 0, "Clue:", "One big drawing is on the wall with an inscription at the bottom. You may want to take a better look at it.");
                RoomClass[32] = new RoomClass(true, true, false, 133, 0, 30, 31, 0, 0, "Bitter Sweet: ", "There is a beautiful young woman pacing back and forth. ");
                RoomClass[33] = new RoomClass(true, false, false, 0, 234, 32, 235, 0, 0, "Trophy Room: ", "A massive room and the only thing in it is a piller with the Golden Blizing on it trapped within a cage with a lock on the outside. Looks like one more riddle ");
                RoomClass[34] = new RoomClass(true, false, false, 0, 28, 0, 33, 0, 0, "All knowing: ", "A small girl sits in a little rocking chair reading a book, /Listen/ She says and hear of this place.");
                RoomClass[35] = new RoomClass(true, false, false, 0, 33, 0, 0, 0, 0, "Credits: ", "    ");
                RoomClass[41] = new RoomClass(true, false, false, 10, 0, 0, 42, 0, 0, "Grand Room: ", "Lots of golden furniture. Look that fruit looks as if it was just picked.");
                RoomClass[42] = new RoomClass(true, false, false, 0, 41, 243, 0, 0, 0, "Black Out: ", "The room is so dark walking in, the tourch light seems to be engulfed by the darkness. Was that a noise?");
                RoomClass[43] = new RoomClass(true, false, false, 43, 0, 233, 0, 0, 0, "Empty: ", "Just stone walls");

                RoomClass[3].roomItem.Add(new ItemClass(10, "GOLD", "Adds to your wealth", 5, 0, 0));
                RoomClass[10].roomItem.Add(new ItemClass(10, "GOLD", "Adds to your wealth", 2, 0, 0));
                RoomClass[14].roomItem.Add(new ItemClass(10, "GOLD", "Adds to your wealth", 5, 0, 0));
                RoomClass[15].roomItem.Add(new ItemClass(10, "GOLD", "Adds to your wealth", 5, 0, 0));
                RoomClass[18].roomItem.Add(new ItemClass(10, "GOLD", "Adds to your wealth", 5, 0, 0));
                RoomClass[25].roomItem.Add(new ItemClass(10, "GOLD", "Adds to your wealth", 5, 0, 0));
                RoomClass[29].roomItem.Add(new ItemClass(10, "GOLD", "Adds to your wealth", 5, 0, 0));
                RoomClass[41].roomItem.Add(new ItemClass(10, "GOLD", "Adds to your wealth", 5, 0, 0));
                RoomClass[43].roomItem.Add(new ItemClass(10, "GOLD", "Adds to your wealth", 20, 0, 0));

                RoomClass[2].roomItem.Add(new ItemClass(1, "TORCH", "Lights Up The Room", 0, 1, 3));
                RoomClass[2].roomItem.Add(new ItemClass(9, "AXE", "Good for cutting down monsters", 4, 5, 3));
                RoomClass[4].roomItem.Add(new ItemClass(10, "Mace", "Nothing like hammereing monsters to the ground", 4, 5, 3));
                RoomClass[5].roomItem.Add(new ItemClass(100, "BOOK", "a book that allows you to translate hints on the walls", 50, 75, 0));
                RoomClass[6].roomItem.Add(new ItemClass(20, "ARMOR", "Protects you in fights, increases health", 10, 30, 2));
                RoomClass[6].roomItem.Add(new ItemClass(7, "SLING", "Protects you in fights, increases health", 10, 30, 0));
                RoomClass[6].roomItem.Add(new ItemClass(8, "STONES", "Protects you in fights, increases health", 10, 30, 2));
                RoomClass[10].roomItem.Add(new ItemClass(2, "KNIFE", "Sharp And Pointy, great for chopping", 3, 10, 2));
                RoomClass[11].roomItem.Add(new ItemClass(2, "KNIFE", "Sharp And Pointy, great for chopping", 3, 10, 2));
                RoomClass[12].roomItem.Add(new ItemClass(99, "INSTRUMENT1", "Snake charmer: hypnotises snakes", 15, 3, 1));
                RoomClass[12].roomItem.Add(new ItemClass(98, "INSTRUMENT2", "Pettler Flute: Playing this weakens monsters", 15, 3, 1));
                RoomClass[12].roomItem.Add(new ItemClass(98, "INSTRUMENT3", "Harmonica: a fun little instrument", 3, 3, 1));
                RoomClass[14].roomItem.Add(new ItemClass(-22, "BALLS", "Probably worth a bit of money", 15, 5, 3));
                RoomClass[30].roomItem.Add(new ItemClass(3, "SWORD", "Weapon for a hero", 5, 10, 5));
                RoomClass[30].roomItem.Add(new ItemClass(4, "SPEARS", "Perfect at throwing at monsters", 3, 3, 3));
                RoomClass[30].roomItem.Add(new ItemClass(5, "BOW", "great for shooting arrows", 3, 40, 0));
                RoomClass[30].roomItem.Add(new ItemClass(6, "ARROWS", "Can be shot out of a bow", 3, 5, 3));
                RoomClass[30].roomItem.Add(new ItemClass(6, "ARROWS", "Can be shot out of a bow", 3, 5, 3));
                RoomClass[33].roomItem.Add(new ItemClass(-101, "BLIZING", "A Priceless artifact", 800, 0, 0));


               RoomClass[5].helper[5] = new HelperClass(1, "Oberon: ", "Welcome, " + Name + ",  I am Oberon. Type the number associated with each question for me to answer.");
                RoomClass[5].helper[5].QA.Add(new QandA(1, "Where am I and how do I get the Blizing?", "Welcome to the Temple Weather and Seasons, To get the blizing you just have to get to it alive."));
                RoomClass[5].helper[5].QA.Add(new QandA(2, "What challenges will I have to face?", " This temple has been lined with riddles, monsters, and traps garding the blizing. Of corse we all have some hidden shortcuts..."));
                RoomClass[5].helper[5].QA.Add(new QandA(3, "What if I get lost?", "Helpers are around the temple, If you can read hyroglyphs the walls will be helpful. There may or may not be a translation book around these few rooms."));
                RoomClass[5].helper[5].QA.Add(new QandA(4, "Riddles? ", "Riddle 1: I’m often pointed at the sky but I’m not a satellite dish"));
                RoomClass[5].helper[5].QA.Add(new QandA(-5, "Fighting? ", "Shooting from a distance doesn't do much dammage but it reduces your risk for injury"));

                RoomClass[21].helper[21] = new HelperClass(2, "Argus: ", "Hi, " + Name + "!  I'm Argus. Can I be of any assistance?");
                RoomClass[21].helper[21].QA.Add(new QandA(1, "Riddle Help?", "Riddle 4: I’m sometimes part of a man but I don’t have any skin"));
                RoomClass[21].helper[21].QA.Add(new QandA(2, "Fighting Help?", "Fighting with close range weapons do more dammage, but it's easier for a monster to attack you."));
                RoomClass[21].helper[21].QA.Add(new QandA(3, "Who's a good dog?", "I suppose you want me to spin around and wag my tail"));

                RoomClass[22].helper[22] = new HelperClass(3, "Anonymous: ", "Hello, " + Name + ", How can I assist you?");
                RoomClass[22].helper[22].QA.Add(new QandA(1, "Who are you?", "Was that a personal question? Who I am is no concern to you."));
                RoomClass[22].helper[22].QA.Add(new QandA(2, "How should I prepair for the next monster?", "Make sure you have weapons that can shoot as far as the sun"));
                RoomClass[22].helper[22].QA.Add(new QandA(3, "How many riddles are there?", " with four riddles, remember for number 3: It flows but it is not a bloodstream "));
                RoomClass[22].helper[22].QA.Add(new QandA(-4, "Any more hints for riddle 3", " It is full of water but it isn't a fish tank "));

                RoomClass[25].helper[25] = new HelperClass(4, "Urisk : ", "Hey, " + Name + ",  I supose you are looking for the Blizing.");
                RoomClass[25].helper[25].QA.Add(new QandA(1, "What are your friends and can you tell them to knock it off with the berries??!", "We are Dryads, they are protecting their tree, but, Guys Stop it! *they stop*"));
                RoomClass[25].helper[25].QA.Add(new QandA(2, "Do you have any hints for future riddles?", " Let me see.. Riddle 2: I’m in the Wizard Of Oz but I’m not a witch"));
                RoomClass[25].helper[25].QA.Add(new QandA(3, "Any other hints for riddles?", " Let me see.. Riddle 4: I get warm enough I go away but I’m not a winter wardrobe "));
                RoomClass[25].helper[25].QA.Add(new QandA(-4, "Why aren't you flying around having a good time? ", "I have no tree, I save my energy until my time comes to change over the seasons."));

                RoomClass[9].monster[9] = new MonsterClass("Mutant Chimpazape ", "Like you only bigger, meaner, hairier and about 5 times as strong", 12, 2, true, true);
                RoomClass[23].monster[23] = new MonsterClass("Golden Griffin", "While majestic in flight these enormous animals don’t pay much attention to what they grab up for dinner, be it a sheep, a goat, or you", 12, 4, true, false);
                RoomClass[25].monster[25] = new MonsterClass("Dryads ", "Small balls of light swarming the giant tree in the center. T00 Small And Numorous To Fight, but the berries they are throwing at you are annoying. ", 10000, 0, true, false);
                RoomClass[32].monster[32] = new MonsterClass("Ice Woman", "Her hands look Cold as Ice and her hair is frozen over. You walk towards her and when you're close enough she hits you hard wih her frozen boots.", 20, 4, true, true);

                RoomClass[14].riddle.Add(new RiddleClass(14, 1, 5, "This thing is usually green, But it’s not a plate of peas, In fall I fall from great heights", "", false));
                RoomClass[26].riddle.Add(new RiddleClass(26, 2, 5, "I have an eye but I can’t see, I rotate but I’m not the earth, I have a spout but I’m not a teapot ", "Tornado", false));
                RoomClass[27].riddle.Add(new RiddleClass(27, 3, 5, " I have a source but I’m not a journalist, I have a delta but I’m not a Greek alphabet, I have banks on both sides of me but I’m not surrounded by money", "RIVER", false));
                RoomClass[33].riddle.Add(new RiddleClass(33, 4, 5, "I fall but I never get back up, I’m unique but I’m not a fingerprint, I’m sometimes part of a ball but I’m not leather ", "SNOW", false));

            }

            //A bit underprepaired, but great at asking questions that could be extra useful
            CharacterClass Tourist = new CharacterClass(1, Name, "Tourist: you are able to ask extra questions that others may not think about", ", You're not familier with the area, but walking away from the tour group was a adventurous descision " +
                "that has brought you to an acient temple. You had heard the tourest guide say something about a priceless, long lost Golden Blizing that is somewhere in there. ", 10, 10, 0, 7, 2);
            CharacterClass Archaeologist = new CharacterClass(2, Name, "Archaeologist: Temples like these are your specialty, you understand the hyroglif meanings and don't need a translator.", ", You have been studying temples like this one for years, when you heard about the priceless, long lost," +
                "Golden Blizing you had to come take a look. ", 10, 10, 0, 7, 3);
            CharacterClass HomeDesigner = new CharacterClass(3, Name, "Home Designer: You know when a wall looks funky, you can easily find passages others might not have thought about.", ", A very well off client has asked you to design a get-away home for them. They wanted it to feel like" +
                "it was an acient temple, and this one caught your eye. When looking around at the features someone told you about a priceless, long lost Golden Blizing. ", 10, 10, 5, 7, 3);
            CharacterClass Soldier = new CharacterClass(4, Name, "Soldier: You are skilled in combat and can take on whatever comes your way.", ", Your day off from training, a few of your friends " +
                " dared you to go into the cave and look for the priceless, long lost Golden Blizing. You're not chicken are you?", 12, 12, 0, 5, 5);
            CharacterClass NativeChild = new CharacterClass(5, Name, "Native Child: you have heard all the riddles and stories before, all you have to do is remember.",
                ", You are young to go to school, but adventure is running through your veins. After hearing Papie tell you stories of the priceless, long lost Golden Blizing you decided that you were going to bring it back to him", 10, 10, 10, 10, 1);




            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("  Type the corresponding number with the character you would like to be: ");
            Console.ResetColor();
            Console.WriteLine("1. " + Tourist.ToString());
            Console.WriteLine("2. " + Archaeologist.ToString());
            Console.WriteLine("3. " + HomeDesigner.ToString());
            Console.WriteLine("4. " + Soldier.ToString());
            Console.WriteLine("5. " + NativeChild.ToString());
            Console.WriteLine();

            int userNumber;
            double userHealth = 10;
            int userPower = 1;
            bool work = false;
            do
            {
                userNumber = EnterAnInt();
                if (userNumber == 1 || userNumber == 2 || userNumber == 3 || userNumber == 4 || userNumber == 5)
                {
                    Console.WriteLine();
                    work = true;
                }
                else
                {
                    Console.WriteLine("try again");
                    Console.WriteLine();
                }
            } while (work != true);

            if (userNumber == Tourist.CharacterNumber)
            {
                userHealth = Tourist.Health;
                userPower = Tourist.CharacterStrength;
                Console.WriteLine(Name + Tourist.CharacterInfo);
            }
            else if (userNumber == Archaeologist.CharacterNumber)
            {
                userHealth = Archaeologist.Health;
                userPower = Archaeologist.CharacterStrength;
                Console.WriteLine(Name + Archaeologist.CharacterInfo);
            }
            else if (userNumber == HomeDesigner.CharacterNumber)
            {
                userHealth = HomeDesigner.Health;
                userPower = HomeDesigner.CharacterStrength;
                Console.WriteLine(Name + HomeDesigner.CharacterInfo);
            }
            else if (userNumber == Soldier.CharacterNumber)
            {
                userHealth = Soldier.Health;
                userPower = Soldier.CharacterStrength;
                Console.WriteLine(Name + Soldier.CharacterInfo);
            }
            else if (userNumber == NativeChild.CharacterNumber)
            {
                userHealth = NativeChild.Health;
                userPower = NativeChild.CharacterStrength;
                Console.WriteLine(Name + NativeChild.CharacterInfo);
            }
            Console.WriteLine("Ready to go? Press ENTER to continue.");
            command = Console.ReadLine().ToUpper();
            string[] commandWords = command.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            Console.Clear();

            //Game Loop
            do
            {
                if (RoomClass[currentRoom].HasHelper == true && RoomClass[currentRoom].HasMonster != true)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.Clear();
                }
                else if(RoomClass[currentRoom].HasMonster == true && RoomClass[currentRoom].HasHelper != true)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.Clear();
                }
                else if (RoomClass[currentRoom].HasMonster == true && RoomClass[currentRoom].HasHelper == true)
                {
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.Clear();
                }
                else
                {
                    if (Console.BackgroundColor != ConsoleColor.Black)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                    }
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                                    Console.WriteLine();
                //NEED TORCH
                if (RoomClass[currentRoom] == RoomClass[1] || RoomClass[currentRoom] == RoomClass[2])
                {
                    Console.WriteLine(RoomClass[currentRoom].visitRoom());
                }
                else if (inventory.Contains(inventory.Find(item => item.ItemName == "TORCH")))
                {
                    Console.WriteLine(RoomClass[currentRoom].visitRoom());
                }
                else
                {
                    Console.WriteLine("It's Too dark in here to see, we need a torch");
                    Console.WriteLine("type help for commands");
                }
                Console.WriteLine("Command (N,E,S,W,U,D,Q): ");

                if (RoomClass[currentRoom].ToNorth >= 200)
                {
                    if (userNumber == HomeDesigner.CharacterNumber)
                    {
                        Console.WriteLine("The north wall look a bit funny, might want to search the room");
                    }
                }
                if (RoomClass[currentRoom].ToEast >= 200)
                {
                    if (userNumber == HomeDesigner.CharacterNumber)
                    {
                        Console.WriteLine("The east wall look a bit funny, might want to search the room");
                    }
                }
                if (RoomClass[currentRoom].ToSouth >= 200)
                {
                    if (userNumber == HomeDesigner.CharacterNumber)
                    {
                        Console.WriteLine("The south wall look a bit funny, might want to search the room");
                    }
                }
                if (RoomClass[currentRoom].ToWest >= 200)
                {
                    if (userNumber == HomeDesigner.CharacterNumber)
                    {
                        Console.WriteLine("The west wall look a bit funny, might want to search the room");
                    }
                }
                if (RoomClass[currentRoom].ToUp >= 200)
                {
                    if (userNumber == HomeDesigner.CharacterNumber)
                    {
                        Console.WriteLine("The floor look a bit funny, might want to search the room");
                    }
                }
                if (RoomClass[currentRoom].ToDown >= 200)
                {
                    if (userNumber == HomeDesigner.CharacterNumber)
                    {
                        Console.WriteLine("The ceiling look a bit funny, might want to search the room");
                    }
                }

                command = Console.ReadLine().ToUpper();
                commandWords = command.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

                //Single letter Directrions
                if (commandWords.Length == 1)
                {
                    if (commandWords[0] == "N" || commandWords[0] == "E" || commandWords[0] == "S" || commandWords[0] == "W" || commandWords[0] == "U" || commandWords[0] == "D" ||
                        commandWords[0] == "NORTH" || commandWords[0] == "EAST" || commandWords[0] == "SOUTH" || commandWords[0] == "WEST" ||
                        commandWords[0] == "UP" || commandWords[0] == "Down")
                    {

                        if (commandWords[0] == "N" && RoomClass[currentRoom].ToNorth > 0 && RoomClass[currentRoom].ToNorth < 100 ||
                            commandWords[0] == "NORTH" && RoomClass[currentRoom].ToNorth > 0 && RoomClass[currentRoom].ToNorth < 100)
                        {
                            currentRoom = RoomClass[currentRoom].ToNorth;
                            Console.WriteLine();
                        }
                        else if (commandWords[0] == "E" && RoomClass[currentRoom].ToEast > 0 && RoomClass[currentRoom].ToEast < 100 ||
                            commandWords[0] == "EAST" && RoomClass[currentRoom].ToEast > 0 && RoomClass[currentRoom].ToEast < 100)
                        {
                            currentRoom = RoomClass[currentRoom].ToEast;
                            Console.WriteLine();

                        }
                        else if (commandWords[0] == "S" && RoomClass[currentRoom].ToSouth > 0 && RoomClass[currentRoom].ToSouth < 100 ||
                            commandWords[0] == "SOUTH" && RoomClass[currentRoom].ToSouth > 0 && RoomClass[currentRoom].ToSouth < 100)
                        {
                            currentRoom = RoomClass[currentRoom].ToSouth;
                            Console.WriteLine();

                        }
                        else if (commandWords[0] == "W" && RoomClass[currentRoom].ToWest > 0 && RoomClass[currentRoom].ToWest < 100 ||
                            commandWords[0] == "WEST" && RoomClass[currentRoom].ToWest > 0 && RoomClass[currentRoom].ToWest < 100)
                        {
                            currentRoom = RoomClass[currentRoom].ToWest;
                            Console.WriteLine();

                        }
                        else if (commandWords[0] == "U" && RoomClass[currentRoom].ToUp > 0 && RoomClass[currentRoom].ToUp < 100 ||
                            commandWords[0] == "UP" && RoomClass[currentRoom].ToUp > 0 && RoomClass[currentRoom].ToUp < 100)
                        {
                            currentRoom = RoomClass[currentRoom].ToUp;
                            Console.WriteLine();

                        }
                        else if (commandWords[0] == "D" && RoomClass[currentRoom].ToDown > 0 && RoomClass[currentRoom].ToDown < 100 ||
                            commandWords[0] == "Down" && RoomClass[currentRoom].ToDown > 0 && RoomClass[currentRoom].ToDown < 100)
                        {
                            currentRoom = RoomClass[currentRoom].ToDown;
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Sorry, You can't go that way ");
                            Console.WriteLine();
                        }
                    }

                    //Finds Hidden Rooms
                    else if (commandWords[0] == "SEARCH")
                    {
                        if (RoomClass[currentRoom].ToNorth >= 200)
                        {
                            Console.WriteLine("You have found a passage, Now You Can See Where It Leads");
                            Console.WriteLine();
                            RoomClass[currentRoom].ToNorth = RoomClass[currentRoom].ToNorth - 200;
                        }
                        if (RoomClass[currentRoom].ToEast >= 200)
                        {
                            Console.WriteLine("You have found a passage, Now You Can See Where It Leads");
                            Console.WriteLine();
                            RoomClass[currentRoom].ToEast = RoomClass[currentRoom].ToEast - 200;
                        }
                        if (RoomClass[currentRoom].ToSouth >= 200)
                        {
                            Console.WriteLine("You have found a passage, Now You Can See Where It Leads");
                            Console.WriteLine();
                            RoomClass[currentRoom].ToSouth = RoomClass[currentRoom].ToSouth - 200;
                        }
                        if (RoomClass[currentRoom].ToWest >= 200)
                        {
                            Console.WriteLine("You have found a passage, Now You Can See Where It Leads");
                            Console.WriteLine();
                            RoomClass[currentRoom].ToWest = RoomClass[currentRoom].ToWest - 200;
                        }
                        if (RoomClass[currentRoom].ToUp >= 200)
                        {
                            Console.WriteLine("You have found a passage, Now You Can See Where It Leads");
                            Console.WriteLine();
                            RoomClass[currentRoom].ToUp = RoomClass[currentRoom].ToUp - 200;
                        }
                        if (RoomClass[currentRoom].ToDown >= 200)
                        {
                            Console.WriteLine("You have found a passage, Now You Can See Where It Leads");
                            Console.WriteLine();
                            RoomClass[currentRoom].ToDown = RoomClass[currentRoom].ToDown - 200;
                        }
                    }
                    else if( commandWords[0] == "CHARACTER" || commandWords[0] == Name)
                    {
                        if (userNumber == Tourist.CharacterNumber)
                        {
                            Console.WriteLine(Tourist.ToString());
                        }
                        else if (userNumber == Archaeologist.CharacterNumber)
                        {
                            Console.WriteLine(Archaeologist.ToString());
                        }
                        else if (userNumber == HomeDesigner.CharacterNumber)
                        {
                            Console.WriteLine(HomeDesigner.ToString());
                        }
                        else if (userNumber == Soldier.CharacterNumber)
                        {
                            Console.WriteLine(Soldier.ToString());
                        }
                        else if (userNumber == NativeChild.CharacterNumber)
                        {
                            Console.WriteLine(NativeChild.ToString());
                        }
                    }
                    else if(commandWords[0] == "Q")
                    {

                    }
                    else if (commandWords[0] == "LOOK")
                    {
                        Console.WriteLine();
                        Console.WriteLine(RoomClass[currentRoom].RoomDescription);
                        Console.WriteLine();
                    }
                    else if( commandWords[0] == "SOLVE")
                    {
                        string again = "";
                        string guess = "";
                        bool solved = false;
                        do
                        {
                            Console.WriteLine(RoomClass[currentRoom].riddle.Find(riddle => riddle.RiddleNumber == currentRoom).TryCount + " Trys Left");
                            Console.WriteLine(RoomClass[currentRoom].riddle.Find(riddle => riddle.RiddleNumber == currentRoom).WrittenNumber + ": " +
                            RoomClass[currentRoom].riddle.Find(riddle => riddle.RiddleNumber == currentRoom).Riddle);
                            Console.WriteLine();
                            Console.WriteLine("What am I?");
                            guess = Console.ReadLine().ToUpper();
                            if (guess == RoomClass[currentRoom].riddle.Find(riddle => riddle.RiddleNumber == currentRoom).RiddleAnswer)
                            {
                                if (RoomClass[currentRoom].roomItem.Find(item => item.ItemNumber < 0) != null)
                                {
                                    RoomClass[currentRoom].roomItem.Find(item => item.ItemNumber < 0).ItemNumber *= (-1);
                                }

                                solved = true;
                                RoomClass[currentRoom].RiddleSolved = true;

                                if (RoomClass[currentRoom].ToNorth < 0)
                                {
                                    RoomClass[currentRoom].ToNorth = RoomClass[currentRoom].ToNorth * (-1);
                                }
                                if (RoomClass[currentRoom].ToEast < 0)
                                {
                                    RoomClass[currentRoom].ToEast = RoomClass[currentRoom].ToEast * (-1);
                                }
                                if (RoomClass[currentRoom].ToSouth < 0)
                                {
                                    RoomClass[currentRoom].ToSouth = RoomClass[currentRoom].ToSouth * (-1);
                                }
                                if (RoomClass[currentRoom].ToWest < 0)
                                {
                                    RoomClass[currentRoom].ToWest = RoomClass[currentRoom].ToWest * (-1);
                                }
                                if (RoomClass[currentRoom].ToUp < 0)
                                {
                                    RoomClass[currentRoom].ToUp = RoomClass[currentRoom].ToUp * (-1);
                                }
                                if (RoomClass[currentRoom].ToDown < 0)
                                {
                                    RoomClass[currentRoom].ToDown = RoomClass[currentRoom].ToDown * (-1);
                                }
                                Console.WriteLine("You guessed correctly! ");
                                again = "N";
                            }
                            else
                            {
                                RoomClass[currentRoom].riddle.Find(riddle => riddle.RiddleNumber == currentRoom).TryCount -= 1;
                                if (RoomClass[currentRoom].riddle.Find(riddle => riddle.RiddleNumber == currentRoom).TryCount < 0)
                                {
                                    Console.WriteLine("Out of trys");
                                    lose = true;
                                    again = "N";
                                }
                                else
                                {
                                    Console.WriteLine("Incorrect: Would you like to try again? Y/N");
                                    again = Console.ReadLine().ToUpper();
                                }
                            }
                        } while (again != "N" && RoomClass[currentRoom].riddle.Find(riddle => riddle.RiddleNumber == currentRoom).TryCount > 0 || 
                        solved != true  && RoomClass[currentRoom].riddle.Find(riddle => riddle.RiddleNumber == currentRoom).TryCount > 0);
                        if (RoomClass[currentRoom].RiddleSolved != true)
                        {
                            lose = true;
                            commandWords[0] = "Q";
                        }
                    }
                    else if(commandWords[0] == "FIGHT" || commandWords[0] == "ATTACK")
                    {
                        if(RoomClass[currentRoom].HasMonster == true)
                        {
                            if(RoomClass[currentRoom].monster[currentRoom].IsAlive == true)
                            {
                                string action = "";
                                int weaponNumber;

                                if (RoomClass[currentRoom].monster[currentRoom].FightClose == true)
                                {
                                    do
                                    {
                                        Console.WriteLine("What is the number of the item you would like to attack with?");
                                        Console.WriteLine();

                                        Console.WriteLine("1. Fists: Only your power");
                                        if (inventory.Contains(inventory.Find(item => item.ItemNumber == 2)))
                                        {
                                            Console.WriteLine("2. Knife: incrreases your power by 2");
                                        }
                                        if (inventory.Contains(inventory.Find(item => item.ItemNumber == 3)))
                                        {
                                            Console.WriteLine("3. Sword: incrreases your power by 5");
                                        }
                                        if (inventory.Contains(inventory.Find(item => item.ItemNumber == 4)))
                                        {
                                            Console.WriteLine("4. Spears: can inflict 3 dammage");
                                        }
                                        if (inventory.Contains(inventory.Find(item => item.ItemNumber == 5)) && inventory.Contains(inventory.Find(item => item.ItemNumber == 6)))
                                        {
                                            Console.WriteLine("5. Bow and Arrows: can inflict 3 dammage");
                                        }
                                        if (inventory.Contains(inventory.Find(item => item.ItemNumber == 7)) && inventory.Contains(inventory.Find(item => item.ItemNumber == 8)))
                                        {
                                            Console.WriteLine("6. Sling and Stones: can inflict 2 dammage");
                                        }
                                        if (inventory.Contains(inventory.Find(item => item.ItemNumber == 9)))
                                        {
                                            Console.WriteLine("7. Axe:  incrreases your power by 2");
                                        }
                                        if (inventory.Contains(inventory.Find(item => item.ItemNumber == 10)))
                                        {
                                            Console.WriteLine("8. Mace:  incrreases your power by 3");
                                        }

                                        weaponNumber = EnterAnInt();

                                        if(weaponNumber == 1)
                                        {
                                            int attack = rnd.Next(1, 4);
                                            int defense = rnd.Next(1, 6);
                                            //you attack
                                            if (attack <= 2)
                                            {
                                                RoomClass[currentRoom].monster[currentRoom].MonsterHealth -= - userPower;
                                                Console.WriteLine("You successfully attacked with your fists! The monster's health is now down to " + RoomClass[currentRoom].monster[currentRoom].MonsterHealth);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Attacking using your fists failed. The monster's health is still at " + RoomClass[currentRoom].monster[currentRoom].MonsterHealth);
                                            }
                                            //monster attack
                                            if(defense <= 4)
                                            {
                                                userHealth -= RoomClass[currentRoom].monster[currentRoom].MonsterStrength;
                                                Console.WriteLine("The monster swings back and hits you. Your health is now " + userHealth);
                                            }
                                            else
                                            {
                                                Console.WriteLine("The monster took a swing at you, but you dogded it. Your health is still " + userHealth);
                                            }
                                        }
                                        else if(weaponNumber == 2)
                                        {
                                            int attack = rnd.Next(1, 5);
                                            int defense = rnd.Next(1, 5);
                                            //you attack
                                            if (attack <= 3)
                                            {
                                                RoomClass[currentRoom].monster[currentRoom].MonsterHealth -= inventory.Find(item => item.ItemNumber == 2).ItemPower + userPower;
                                                Console.WriteLine("You successfully attacked with a knife! The monster's health is now down to " + RoomClass[currentRoom].monster[currentRoom].MonsterHealth);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Attacking using a knife failed. The monster's health is still at " + RoomClass[currentRoom].monster[currentRoom].MonsterHealth);
                                            }
                                            //monster attack
                                            if (defense <= 3)
                                            {
                                                userHealth -= RoomClass[currentRoom].monster[currentRoom].MonsterStrength;
                                                Console.WriteLine("The monster swings back and hits you. Your health is now " + userHealth);
                                            }
                                            else
                                            {
                                                Console.WriteLine("The monster took a swing at you, but you dogded it. Your health is still " + userHealth);
                                            }
                                            //weapon use
                                            inventory.Find(item => item.ItemNumber == 2).ItemWearLevel -= 1;
                                            if(inventory.Find(item => item.ItemNumber == 2).ItemWearLevel > 0)
                                            {
                                                Console.WriteLine("You can use your knife " + inventory.Find(item => item.ItemNumber == 2).ItemWearLevel + " more times.");
                                            }
                                            else if (inventory.Find(item => item.ItemNumber == 2).ItemWearLevel == 0)
                                            {
                                                inventory.Remove(inventory.Find(item => item.ItemName == "Knife"));
                                                Console.WriteLine("Your knife is badly bent and you can no longer use it");
                                            }
                                        }
                                        else if(weaponNumber == 3)
                                        {
                                            int attack = rnd.Next(1, 9);
                                            int defense = rnd.Next(1, 5);
                                            //you attack
                                            if (attack <= 7)
                                            {
                                                RoomClass[currentRoom].monster[currentRoom].MonsterHealth -= (inventory.Find(item => item.ItemNumber == 3).ItemPower + userPower);
                                                Console.WriteLine("You successfully attacked with a sword! The monster's health is now down to " + RoomClass[currentRoom].monster[currentRoom].MonsterHealth);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Attacking using a sword failed. The monster's health is still at " + RoomClass[currentRoom].monster[currentRoom].MonsterHealth);
                                            }
                                            //monster attack
                                            if (defense <= 3)
                                            {
                                                userHealth -= RoomClass[currentRoom].monster[currentRoom].MonsterStrength;
                                                Console.WriteLine("The monster swings back and hits you. Your health is now " + userHealth);
                                            }
                                            else
                                            {
                                                Console.WriteLine("The monster took a swing at you, but you dogded it. Your health is still " + userHealth);
                                            }
                                            //weapon use
                                            inventory.Find(item => item.ItemNumber == 3).ItemWearLevel -= 1;
                                            if (inventory.Find(item => item.ItemNumber == 3).ItemWearLevel > 0)
                                            {
                                                Console.WriteLine("You can use your sword " + inventory.Find(item => item.ItemNumber == 2).ItemWearLevel + " more times.");
                                            }
                                            else if (inventory.Find(item => item.ItemNumber == 2).ItemWearLevel == 0)
                                            {
                                                inventory.Remove(inventory.Find(item => item.ItemName == "SWORD"));
                                                Console.WriteLine("Your sword is badly bent and you can no longer use it");
                                            }
                                        }
                                        else if(weaponNumber == 4)
                                        {
                                            int attack = rnd.Next(1, 8);
                                            int defense = rnd.Next(1, 10);
                                            //you attack
                                            if (attack <= 3)
                                            {
                                                RoomClass[currentRoom].monster[currentRoom].MonsterHealth -= (inventory.Find(item => item.ItemNumber == 4).ItemPower + userPower);
                                                Console.WriteLine("You successfully shot the monster with a spear! The monster's health is now down to " + RoomClass[currentRoom].monster[currentRoom].MonsterHealth);
                                            }
                                            else
                                            {
                                                Console.WriteLine("The spear failed to hit the monster. The monster's health is still at " + RoomClass[currentRoom].monster[currentRoom].MonsterHealth);
                                            }
                                            //monster attack
                                            if (defense <= 1)
                                            {
                                                userHealth -= RoomClass[currentRoom].monster[currentRoom].MonsterStrength;
                                                Console.WriteLine("The monster runs up and attacks you. Your health is now " + userHealth);
                                            }
                                            else
                                            {
                                                Console.WriteLine("The monster didn't run to attack you. Your health is still " + userHealth);
                                            }
                                            //weapon use
                                            inventory.Find(item => item.ItemNumber == 4).ItemWearLevel -= 1;
                                            if (inventory.Find(item => item.ItemNumber == 4).ItemWearLevel > 0)
                                            {
                                                Console.WriteLine("You have " + inventory.Find(item => item.ItemNumber == 4).ItemWearLevel + " spears left.");
                                            }
                                            else if (inventory.Find(item => item.ItemNumber == 4).ItemWearLevel == 0)
                                            {
                                                inventory.Remove(inventory.Find(item => item.ItemName == "SPEARS"));
                                                Console.WriteLine("You ran out of spears");
                                            }
                                        }
                                        else if(weaponNumber == 5)
                                        {
                                            int attack = rnd.Next(1, 3);
                                            int defense = rnd.Next(1, 11);
                                            //you attack
                                            if (attack <= 1)
                                            {
                                                RoomClass[currentRoom].monster[currentRoom].MonsterHealth -= (inventory.Find(item => item.ItemNumber == 6).ItemPower);
                                                Console.WriteLine("You successfully shot the monster using the bow and arrows! The monster's health is now down to " + RoomClass[currentRoom].monster[currentRoom].MonsterHealth);
                                            }
                                            else
                                            {
                                                Console.WriteLine("The arrow failed to hit the monster. The monster's health is still at " + RoomClass[currentRoom].monster[currentRoom].MonsterHealth);
                                            }
                                            //monster attack
                                            if (defense <= 1)
                                            {
                                                userHealth -= RoomClass[currentRoom].monster[currentRoom].MonsterStrength;
                                                Console.WriteLine("The monster runs up and attacks you. Your health is now " + userHealth);
                                            }
                                            else
                                            {
                                                Console.WriteLine("The monster didn't run to attack you. Your health is still " + userHealth);
                                            }
                                            //weapon use
                                            inventory.Find(item => item.ItemNumber == 6).ItemWearLevel -= 1;
                                            if (inventory.Find(item => item.ItemNumber == 6).ItemWearLevel > 0)
                                            {
                                                Console.WriteLine("You have " + inventory.Find(item => item.ItemNumber == 6).ItemWearLevel + " arrows left.");
                                            }
                                            else if (inventory.Find(item => item.ItemNumber == 6).ItemWearLevel == 0)
                                            {
                                                inventory.Remove(inventory.Find(item => item.ItemName == "ARROWS"));
                                                Console.WriteLine("You ran out of arrows");
                                            }
                                        }
                                        else if(weaponNumber == 6)
                                        {
                                            int attack = rnd.Next(1, 3);
                                            int defense = rnd.Next(1, 11);
                                            //you attack
                                            if (attack <= 1)
                                            {
                                                RoomClass[currentRoom].monster[currentRoom].MonsterHealth -= (inventory.Find(item => item.ItemNumber == 8).ItemPower);
                                                Console.WriteLine("You successfully shot the monster using the Stones and Sling! The monster's health is now down to " + RoomClass[currentRoom].monster[currentRoom].MonsterHealth);
                                            }
                                            else
                                            {
                                                Console.WriteLine("The Stone failed to hit the monster. The monster's health is still at " + RoomClass[currentRoom].monster[currentRoom].MonsterHealth);
                                            }
                                            //monster attack
                                            if (defense <= 1)
                                            {
                                                userHealth -= RoomClass[currentRoom].monster[currentRoom].MonsterStrength;
                                                Console.WriteLine("The monster runs up and attacks you. Your health is now " + userHealth);
                                            }
                                            else
                                            {
                                                Console.WriteLine("The monster didn't run to attack you. Your health is still " + userHealth);
                                            }
                                            //weapon use
                                            inventory.Find(item => item.ItemNumber == 8).ItemWearLevel -= 1;
                                            if (inventory.Find(item => item.ItemNumber == 8).ItemWearLevel > 0)
                                            {
                                                Console.WriteLine("You have " + inventory.Find(item => item.ItemNumber == 8).ItemWearLevel + " stones left.");
                                            }
                                            else if (inventory.Find(item => item.ItemNumber == 8).ItemWearLevel == 0)
                                            {
                                                inventory.Remove(inventory.Find(item => item.ItemName == "STONES"));
                                                Console.WriteLine("You ran out of stones");
                                            }
                                        }
                                        else if(weaponNumber == 7)
                                        {
                                            int attack = rnd.Next(1, 5);
                                            int defense = rnd.Next(1, 6);
                                            //you attack
                                            if (attack <= 3)
                                            {
                                                RoomClass[currentRoom].monster[currentRoom].MonsterHealth = RoomClass[currentRoom].monster[currentRoom].MonsterHealth - (inventory.Find(item => item.ItemNumber == 9).ItemPower + userPower);
                                                Console.WriteLine("You successfully attacked with an axe! The monster's health is now down to " + RoomClass[currentRoom].monster[currentRoom].MonsterHealth);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Attacking using an axe failed. The monster's health is still at " + RoomClass[currentRoom].monster[currentRoom].MonsterHealth);
                                            }
                                            //monster attack
                                            if (defense <= 4)
                                            {
                                                userHealth = userHealth - RoomClass[currentRoom].monster[currentRoom].MonsterStrength;
                                                Console.WriteLine("The monster swings back and hits you. Your health is now " + userHealth);
                                            }
                                            else
                                            {
                                                Console.WriteLine("The monster took a swing at you, but you dogded it. Your health is still " + userHealth);
                                            }
                                            //weapon use
                                            inventory.Find(item => item.ItemNumber == 9).ItemWearLevel -= 1;
                                            if (inventory.Find(item => item.ItemNumber == 9).ItemWearLevel > 0)
                                            {
                                                Console.WriteLine("You can use your Axe " + inventory.Find(item => item.ItemNumber == 9).ItemWearLevel + " more times.");
                                            }
                                            else if (inventory.Find(item => item.ItemNumber == 9).ItemWearLevel == 0)
                                            {
                                                inventory.Remove(inventory.Find(item => item.ItemName == "AXE"));
                                                Console.WriteLine("Your axe is broken, you can no longer use it");
                                            }
                                        }
                                        else if (weaponNumber == 8)
                                        {
                                            int attack = rnd.Next(1, 7);
                                            int defense = rnd.Next(1, 6);
                                            //you attack
                                            if (attack <= 5)
                                            {
                                                RoomClass[currentRoom].monster[currentRoom].MonsterHealth -= (inventory.Find(item => item.ItemNumber == 10).ItemPower + userPower);
                                                Console.WriteLine("You successfully attacked with a mace! The monster's health is now down to " + RoomClass[currentRoom].monster[currentRoom].MonsterHealth);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Attacking using a mace failed. The monster's health is still at " + RoomClass[currentRoom].monster[currentRoom].MonsterHealth);
                                            }
                                            //monster attack
                                            if (defense <= 4)
                                            {
                                                userHealth -= RoomClass[currentRoom].monster[currentRoom].MonsterStrength;
                                                Console.WriteLine("The monster swings back and hits you. Your health is now " + userHealth);
                                            }
                                            else
                                            {
                                                Console.WriteLine("The monster took a swing at you, but you dogded it. Your health is still " + userHealth);
                                            }
                                            //weapon use
                                            inventory.Find(item => item.ItemNumber == 10).ItemWearLevel -= 1;
                                            if (inventory.Find(item => item.ItemNumber == 10).ItemWearLevel > 0)
                                            {
                                                Console.WriteLine("You can use your mace " + inventory.Find(item => item.ItemNumber == 10).ItemWearLevel + " more times.");
                                            }
                                            else if (inventory.Find(item => item.ItemNumber == 10).ItemWearLevel == 0)
                                            {
                                                inventory.Remove(inventory.Find(item => item.ItemName == "MACE"));
                                                Console.WriteLine("Your mace is badly bent and you can no longer use it");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Not a valid weapon number");
                                        }
                                        //monster health
                                        if(RoomClass[currentRoom].monster[currentRoom].MonsterHealth == 0)
                                        {

                                                        RoomClass[currentRoom].monster[currentRoom].IsAlive = false;

                                            if (RoomClass[currentRoom].ToNorth >= 100 && RoomClass[currentRoom].ToNorth <= 200)
                                            {

                                                RoomClass[currentRoom].ToNorth = RoomClass[currentRoom].ToNorth - 100;
                                            }
                                            if (RoomClass[currentRoom].ToEast >= 100 && RoomClass[currentRoom].ToEast <= 200)
                                            {

                                                RoomClass[currentRoom].ToEast = RoomClass[currentRoom].ToEast - 100;
                                            }
                                            if (RoomClass[currentRoom].ToSouth >= 100 && RoomClass[currentRoom].ToSouth <= 200)
                                            {

                                                RoomClass[currentRoom].ToSouth = RoomClass[currentRoom].ToSouth - 100;
                                            }
                                            if (RoomClass[currentRoom].ToWest >= 100 && RoomClass[currentRoom].ToWest <= 200)
                                            {

                                                RoomClass[currentRoom].ToWest = RoomClass[currentRoom].ToWest - 100;
                                            }
                                            if (RoomClass[currentRoom].ToUp >= 100 && RoomClass[currentRoom].ToUp <= 200)
                                            {

                                                RoomClass[currentRoom].ToUp = RoomClass[currentRoom].ToUp - 100;
                                            }
                                            if (RoomClass[currentRoom].ToDown >= 100 && RoomClass[currentRoom].ToDown <= 200)
                                            {
                                                
                                                RoomClass[currentRoom].ToDown = RoomClass[currentRoom].ToDown - 100;
                                            }


                                        }
                                        if(userHealth <= 0)
                                        {
                                            lose = true;
                                            command = "Q";
                                        }
                                        Console.WriteLine("Would you like to attack again: Y/N");
                                        action = Console.ReadLine().ToUpper();
                                    } while( action != "RUN" || action != "NO"|| action != "N" ||
                                    RoomClass[currentRoom].monster[currentRoom].IsAlive != false || userHealth > 0);                                    
                                }
                                else
                                {
                                    Console.WriteLine("Monster is too far away to fight it with some weapons, what is the number of the weapon you would like to use?");
                                    do
                                    {
                                        if (inventory.Contains(inventory.Find(item => item.ItemNumber == 4)))
                                        {
                                            Console.WriteLine("1. Spears: can inflict 3 additional dammage");
                                        }
                                        if (inventory.Contains(inventory.Find(item => item.ItemNumber == 5)) && inventory.Contains(inventory.Find(item => item.ItemNumber == 6)))
                                        {
                                            Console.WriteLine("2. Bow and Arrows: can inflict 3 dammage");
                                        }
                                        if (inventory.Contains(inventory.Find(item => item.ItemNumber == 7)) && inventory.Contains(inventory.Find(item => item.ItemNumber == 8)))
                                        {
                                            Console.WriteLine("3. Sling and Stones: can inflict 2 dammage");
                                        }
                                        if(!inventory.Contains(RoomClass[currentRoom].roomItem.Find(item => item.ItemNumber == 4)) &&
                                            !inventory.Contains(RoomClass[currentRoom].roomItem.Find(item => item.ItemNumber == 5)) ||
                                            !inventory.Contains(RoomClass[currentRoom].roomItem.Find(item => item.ItemNumber == 6)) &&
                                            !inventory.Contains(RoomClass[currentRoom].roomItem.Find(item => item.ItemNumber == 7)) || 
                                            !inventory.Contains(RoomClass[currentRoom].roomItem.Find(item => item.ItemNumber == 8)))
                                        {
                                            Console.WriteLine("You don't have any weapons to attack this monster");
                                            action = "RUN";
                                            Console.ReadKey();
                                        }

                                        weaponNumber = EnterAnInt();

                                        if (weaponNumber == 1)
                                        {
                                            int attack = rnd.Next(1, 8);
                                            int defense = rnd.Next(1, 10);
                                            //you attack
                                            if (attack <= 3)
                                            {
                                                RoomClass[currentRoom].monster[currentRoom].MonsterHealth -= (inventory.Find(item => item.ItemNumber == 4).ItemPower + userPower);
                                                Console.WriteLine("You successfully shot the monster with a spear! The monster's health is now down to " + RoomClass[currentRoom].monster[currentRoom].MonsterHealth);
                                            }
                                            else
                                            {
                                                Console.WriteLine("The spear failed to hit the monster. The monster's health is still at " + RoomClass[currentRoom].monster[currentRoom].MonsterHealth);
                                            }
                                            //monster attack
                                            if (defense <= 1)
                                            {
                                                userHealth -= RoomClass[currentRoom].monster[currentRoom].MonsterStrength;
                                                Console.WriteLine("The monster runs up and attacks you. Your health is now " + userHealth);
                                            }
                                            else
                                            {
                                                Console.WriteLine("The monster didn't run to attack you. Your health is still " + userHealth);
                                            }
                                            //weapon use
                                            inventory.Find(item => item.ItemNumber == 4).ItemWearLevel -= 1;
                                            if (inventory.Find(item => item.ItemNumber == 4).ItemWearLevel > 0)
                                            {
                                                Console.WriteLine("You have " + inventory.Find(item => item.ItemNumber == 4).ItemWearLevel + " spears left.");
                                            }
                                            else if (inventory.Find(item => item.ItemNumber == 4).ItemWearLevel == 0)
                                            {
                                                inventory.Remove(inventory.Find(item => item.ItemName == "SPEARS"));
                                                Console.WriteLine("You ran out of spears");
                                            }
                                        }
                                        else if (weaponNumber == 2)
                                        {
                                            int attack = rnd.Next(1, 3);
                                            int defense = rnd.Next(1, 11);
                                            //you attack
                                            if (attack <= 1)
                                            {
                                                RoomClass[currentRoom].monster[currentRoom].MonsterHealth -= (inventory.Find(item => item.ItemNumber == 6).ItemPower);
                                                Console.WriteLine("You successfully shot the monster using the bow and arrows! The monster's health is now down to " + RoomClass[currentRoom].monster[currentRoom].MonsterHealth);
                                            }
                                            else
                                            {
                                                Console.WriteLine("The arrow failed to hit the monster. The monster's health is still at " + RoomClass[currentRoom].monster[currentRoom].MonsterHealth);
                                            }
                                            //monster attack
                                            if (defense <= 1)
                                            {
                                                userHealth -= RoomClass[currentRoom].monster[currentRoom].MonsterStrength;
                                                Console.WriteLine("The monster runs up and attacks you. Your health is now " + userHealth);
                                            }
                                            else
                                            {
                                                Console.WriteLine("The monster didn't run to attack you. Your health is still " + userHealth);
                                            }
                                            //weapon use
                                            inventory.Find(item => item.ItemNumber == 6).ItemWearLevel -= 1;
                                            if (inventory.Find(item => item.ItemNumber == 6).ItemWearLevel > 0)
                                            {
                                                Console.WriteLine("You have " + inventory.Find(item => item.ItemNumber == 6).ItemWearLevel + " arrows left.");
                                            }
                                            else if (inventory.Find(item => item.ItemNumber == 6).ItemWearLevel == 0)
                                            {
                                                inventory.Remove(inventory.Find(item => item.ItemName == "ARROWS"));
                                                Console.WriteLine("You ran out of arrows");
                                            }
                                        }
                                        else if (weaponNumber == 3)
                                        {

                                            int attack = rnd.Next(1, 3);
                                            int defense = rnd.Next(1, 11);
                                            //you attack
                                            if (attack <= 1)
                                            {
                                                RoomClass[currentRoom].monster[currentRoom].MonsterHealth -= (inventory.Find(item => item.ItemNumber == 8).ItemPower);
                                                Console.WriteLine("You successfully shot the monster using the Stones and Sling! The monster's health is now down to " + RoomClass[currentRoom].monster[currentRoom].MonsterHealth);
                                            }
                                            else
                                            {
                                                Console.WriteLine("The Stone failed to hit the monster. The monster's health is still at " + RoomClass[currentRoom].monster[currentRoom].MonsterHealth);
                                            }
                                            //monster attack
                                            if (defense <= 1)
                                            {
                                                userHealth -= RoomClass[currentRoom].monster[currentRoom].MonsterStrength;
                                                Console.WriteLine("The monster runs up and attacks you. Your health is now " + userHealth);
                                            }
                                            else
                                            {
                                                Console.WriteLine("The monster didn't run to attack you. Your health is still " + userHealth);
                                            }
                                            //weapon use
                                            inventory.Find(item => item.ItemNumber == 8).ItemWearLevel -= 1;
                                            if (inventory.Find(item => item.ItemNumber == 8).ItemWearLevel > 0)
                                            {
                                                Console.WriteLine("You have " + inventory.Find(item => item.ItemNumber == 8).ItemWearLevel + " stones left.");
                                            }
                                            else if (inventory.Find(item => item.ItemNumber == 8).ItemWearLevel == 0)
                                            {
                                                inventory.Remove(inventory.Find(item => item.ItemName == "STONES"));
                                                Console.WriteLine("You ran out of stones");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Not a valid weapon number");
                                        }
                                        if (RoomClass[currentRoom].monster[currentRoom].MonsterHealth == 0)
                                        {
                                            RoomClass[currentRoom].monster[currentRoom].IsAlive = false;

                                            if (RoomClass[currentRoom].ToNorth >= 100 && RoomClass[currentRoom].ToNorth <= 200)
                                            {

                                                RoomClass[currentRoom].ToNorth = RoomClass[currentRoom].ToNorth - 100;
                                            }
                                            if (RoomClass[currentRoom].ToEast >= 100 && RoomClass[currentRoom].ToEast <= 200)
                                            {

                                                RoomClass[currentRoom].ToEast = RoomClass[currentRoom].ToEast - 100;
                                            }
                                            if (RoomClass[currentRoom].ToSouth >= 100 && RoomClass[currentRoom].ToSouth <= 200)
                                            {

                                                RoomClass[currentRoom].ToSouth = RoomClass[currentRoom].ToSouth - 100;
                                            }
                                            if (RoomClass[currentRoom].ToWest >= 100 && RoomClass[currentRoom].ToWest <= 200)
                                            {

                                                RoomClass[currentRoom].ToWest = RoomClass[currentRoom].ToWest - 100;
                                            }
                                            if (RoomClass[currentRoom].ToUp >= 100 && RoomClass[currentRoom].ToUp <= 200)
                                            {

                                                RoomClass[currentRoom].ToUp = RoomClass[currentRoom].ToUp - 100;
                                            }
                                            if (RoomClass[currentRoom].ToDown >= 100 && RoomClass[currentRoom].ToDown <= 200)
                                            {

                                                RoomClass[currentRoom].ToDown = RoomClass[currentRoom].ToDown - 100;
                                            }

                                        }
                                        if (userHealth <= 0)
                                        {
                                            lose = true;
                                            commandWords[0] = "Q";
                                        }
                                        Console.WriteLine("Would you like to attack again: Y/N");
                                        action = Console.ReadLine().ToUpper();
                                    } while (action != "RUN" || action != "NO" || action != "N" ||
                                    RoomClass[currentRoom].monster[currentRoom].IsAlive != false || userHealth > 0);

                                }
                            }
                            else
                            {
                                Console.WriteLine("The monster is dead, no need to fight it");
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("There is nothing for you to fight here");
                        }
                    }
                    else if (commandWords[0] == "SPEAK" || commandWords[0] == "TALK")
                    {
                        Console.WriteLine();
                        Console.WriteLine(Name + ": Hello?");
                        if (RoomClass[currentRoom].HasHelper == true)
                        {
                            Console.WriteLine(RoomClass[currentRoom].helper[currentRoom].HelperName + RoomClass[currentRoom].helper[currentRoom].HelperInfo);
                            Console.WriteLine();
                            bool again = false;
                            do
                            {
                                foreach (QandA question in RoomClass[currentRoom].helper[currentRoom].QA)
                                {
                                    if (userNumber == Tourist.CharacterNumber && question.QuestionNumber < 0)
                                    {
                                        question.QuestionNumber *= -1;
                                    }
                                    if (question.QuestionNumber > 0)
                                    {
                                        Console.WriteLine(question.QuestionNumber + ": " + question.Question);
                                    }
                                }
                                bool correctQuestion = false;
                                do
                                {
                                    int answerNumber = EnterAnInt();
                                    foreach (QandA question in RoomClass[currentRoom].helper[currentRoom].QA)
                                    {
                                        if (answerNumber == question.QuestionNumber)
                                        {
                                            if (question.QuestionNumber > 0)
                                            {
                                                Console.WriteLine(question.Answer);
                                                correctQuestion = true;
                                            }
                                        }
                                    }
                                } while (correctQuestion != true);
                                Console.WriteLine("Would you like to ask another question? Y/N: ");
                                string goingAgain = Console.ReadLine().ToUpper();
                                if (goingAgain == "Y" || goingAgain == "YES")
                                {
                                    again = true;
                                }
                                else if (goingAgain == "N" || goingAgain == "NO")
                                {
                                    again = false;
                                }
                                else
                                {
                                    Console.WriteLine("I'll Take that as a no");
                                    again = false;
                                }


                            } while (again != false);
                        }
                        else
                        {
                            Console.WriteLine("...");
                            Console.WriteLine("Nothing, looks like there is no one here to speak with");
                        }
                    }
                    else if (commandWords[0] == "HELP")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Type N, S, E, W, U, D to move through rooms");
                        Console.WriteLine("Search: finds secrete rooms");
                        Console.WriteLine("Get OBJECT: allows you to pick up and keep an item");
                        Console.WriteLine("Drop OBJECT: allows you to get rid of an item you are holding");
                        Console.WriteLine("INV: shows you all the objects you are holding");
                        Console.WriteLine("Character: Shows how you are doing");
                        Console.WriteLine("Speak: See if any friendly helpers are in the room");
                        Console.WriteLine("Solve: Will show you the riddle and give you a chance to answer");
                        Console.WriteLine("Fight: Will let you choose your weapon to try and kill the monster");
                        Console.WriteLine("Sell OBJECT: removes that object from the game in return it gives you gold");
                        Console.WriteLine("Q: Quit the game :(");
                        Console.WriteLine();
                        if (Console.BackgroundColor != ConsoleColor.Black)
                        {
                            Console.ReadKey();
                        }
                    }
                    //Command error catch
                    else if (commandWords[0] == "DIG")
                    {
                        Console.WriteLine();
                        Console.WriteLine("What would you like to dig WITH? ");
                        Console.WriteLine();
                    }
                    else if (commandWords[0] == "UNLOCK")
                    {
                        Console.WriteLine("What would you like to unlock that WITH? ");
                        Console.WriteLine();
                    }
                    else if (commandWords[0] == "GET")
                    {
                        Console.WriteLine("What ITEM would you like to get? ");
                        Console.WriteLine();
                    }
                    else if (commandWords[0] == "DROP")
                    {
                        Console.WriteLine("What ITEM would you like to drop? ");
                        Console.WriteLine();
                    }
                    else if (commandWords[0] == "READ")
                    {
                        Console.WriteLine("What would you like to read? ");
                        Console.WriteLine();
                    }
                    // commands with at least three words
                    //check to see what you are carrying
                    else if (commandWords[0].Length >= 3 && commandWords[0].Substring(0, 3) == "INV")
                    {
                        Console.WriteLine("You are carrying the following Items: ");
                        Console.WriteLine();
                        if (inventory.Count == 0)
                        {
                            Console.WriteLine("Nothing");
                            Console.WriteLine();
                        }
                        else
                        {
                            foreach (ItemClass item in inventory)
                            {
                                Console.WriteLine(item.ItemName);
                            }
                            Console.WriteLine();
                        }
                    }
                }
                else if (commandWords.Length == 2)
                {
                    int itemCount = 0;
                    if (commandWords[0] == "GET")
                    {
                        if (RoomClass[currentRoom].roomItem.Find(item => item.ItemName == commandWords[1]) != null)
                        {
                            if(!inventory.Contains(roomItem.Find(item => item.ItemName == commandWords[1])))
                            {
                                if (commandWords[1] == "GOLD")
                                {

                                    if (userNumber == Tourist.CharacterNumber)
                                    {
                                        int goldIncrease = RoomClass[currentRoom].roomItem.Find(item => item.ItemName == "GOLD").ItemValue;
                                        Tourist.GoldHolding += goldIncrease;
                                    }
                                    else if (userNumber == Archaeologist.CharacterNumber)
                                    {
                                        int goldIncrease = RoomClass[currentRoom].roomItem.Find(item => item.ItemName == "GOLD").ItemValue;
                                        Archaeologist.GoldHolding += goldIncrease;
                                    }
                                    else if (userNumber == HomeDesigner.CharacterNumber)
                                    {
                                        int goldIncrease = RoomClass[currentRoom].roomItem.Find(item => item.ItemName == "GOLD").ItemValue;
                                        HomeDesigner.GoldHolding += goldIncrease;
                                    }
                                    else if (userNumber == Soldier.CharacterNumber)
                                    {
                                        int goldIncrease = RoomClass[currentRoom].roomItem.Find(item => item.ItemName == "GOLD").ItemValue;
                                        Soldier.GoldHolding += goldIncrease;
                                    }
                                    else if (userNumber == NativeChild.CharacterNumber)
                                    {
                                        int goldIncrease = RoomClass[currentRoom].roomItem.Find(item => item.ItemName == "GOLD").ItemValue;
                                        NativeChild.GoldHolding += goldIncrease;
                                    }
                                    RoomClass[currentRoom].roomItem.Remove(RoomClass[currentRoom].roomItem.Find(item => item.ItemName == commandWords[1]));
                                }
                                else if (commandWords[1] == "HEART")
                                {
                                    if (userNumber == Tourist.CharacterNumber)
                                    {
                                        if (Tourist.Health + RoomClass[currentRoom].roomItem.Find(item => item.ItemName == "HEART").ItemValue <= Tourist.MaxHealth)
                                        {
                                            Tourist.Health += RoomClass[currentRoom].roomItem.Find(item => item.ItemName == "HEART").ItemValue;
                                            RoomClass[currentRoom].roomItem.Remove(RoomClass[currentRoom].roomItem.Find(item => item.ItemName == commandWords[1]));
                                        }
                                        else if (Tourist.Health >= Tourist.MaxHealth)
                                        {
                                            Console.WriteLine("You are already at full health");
                                        }
                                        else
                                        {
                                            Tourist.Health = Tourist.MaxHealth;
                                            RoomClass[currentRoom].roomItem.Remove(RoomClass[currentRoom].roomItem.Find(item => item.ItemName == commandWords[1]));
                                        }
                                    }
                                    else if (userNumber == Archaeologist.CharacterNumber)
                                    {
                                        if (Archaeologist.Health + RoomClass[currentRoom].roomItem.Find(item => item.ItemName == "HEART").ItemValue <= Tourist.MaxHealth)
                                        {
                                            Archaeologist.Health += RoomClass[currentRoom].roomItem.Find(item => item.ItemName == "HEART").ItemValue;
                                            RoomClass[currentRoom].roomItem.Remove(RoomClass[currentRoom].roomItem.Find(item => item.ItemName == commandWords[1]));
                                        }
                                        else if (Archaeologist.Health >= Archaeologist.MaxHealth)
                                        {
                                            Console.WriteLine("You are already at full health");
                                        }
                                        else
                                        {
                                            Archaeologist.Health = Archaeologist.MaxHealth;
                                            RoomClass[currentRoom].roomItem.Remove(RoomClass[currentRoom].roomItem.Find(item => item.ItemName == commandWords[1]));
                                        }
                                    }
                                    else if (userNumber == HomeDesigner.CharacterNumber)
                                    {
                                        if (HomeDesigner.Health + RoomClass[currentRoom].roomItem.Find(item => item.ItemName == "HEART").ItemValue <= Tourist.MaxHealth)
                                        {
                                            HomeDesigner.Health += RoomClass[currentRoom].roomItem.Find(item => item.ItemName == "HEART").ItemValue;
                                            RoomClass[currentRoom].roomItem.Remove(RoomClass[currentRoom].roomItem.Find(item => item.ItemName == commandWords[1]));
                                        }
                                        else if (HomeDesigner.Health >= HomeDesigner.MaxHealth)
                                        {
                                            Console.WriteLine("You are already at full health");
                                        }
                                        else
                                        {
                                            HomeDesigner.Health = HomeDesigner.MaxHealth;
                                            RoomClass[currentRoom].roomItem.Remove(RoomClass[currentRoom].roomItem.Find(item => item.ItemName == commandWords[1]));
                                        }
                                    }
                                    else if (userNumber == Soldier.CharacterNumber)
                                    {
                                        if (Soldier.Health + RoomClass[currentRoom].roomItem.Find(item => item.ItemName == "HEART").ItemValue <= Tourist.MaxHealth)
                                        {
                                            Soldier.Health += RoomClass[currentRoom].roomItem.Find(item => item.ItemName == "HEART").ItemValue;
                                            RoomClass[currentRoom].roomItem.Remove(RoomClass[currentRoom].roomItem.Find(item => item.ItemName == commandWords[1]));
                                        }
                                        else if (Soldier.Health >= Soldier.MaxHealth)
                                        {
                                            Console.WriteLine("You are already at full health");
                                        }
                                        else
                                        {
                                            Soldier.Health = Soldier.MaxHealth;
                                            RoomClass[currentRoom].roomItem.Remove(RoomClass[currentRoom].roomItem.Find(item => item.ItemName == commandWords[1]));
                                        }
                                    }
                                    else if (userNumber == NativeChild.CharacterNumber)
                                    {
                                        if (NativeChild.Health + RoomClass[currentRoom].roomItem.Find(item => item.ItemName == "HEART").ItemValue <= Tourist.MaxHealth)
                                        {
                                            NativeChild.Health += RoomClass[currentRoom].roomItem.Find(item => item.ItemName == "HEART").ItemValue;
                                            RoomClass[currentRoom].roomItem.Remove(RoomClass[currentRoom].roomItem.Find(item => item.ItemName == commandWords[1]));
                                        }
                                        else if (NativeChild.Health >= NativeChild.MaxHealth)
                                        {
                                            Console.WriteLine("You are already at full health");
                                        }
                                        else
                                        {
                                            NativeChild.Health = NativeChild.MaxHealth;
                                            RoomClass[currentRoom].roomItem.Remove(RoomClass[currentRoom].roomItem.Find(item => item.ItemName == commandWords[1]));
                                        }
                                    }
                                }
                                else
                                {
                                    if (userNumber == Tourist.CharacterNumber)
                                    {
                                        if (itemCount + 1 <= Tourist.ItemLimit)
                                        {
                                            inventory.Add(RoomClass[currentRoom].roomItem.Find(item => item.ItemName == commandWords[1]));
                                            RoomClass[currentRoom].roomItem.Remove(RoomClass[currentRoom].roomItem.Find(item => item.ItemName == commandWords[1]));
                                            Console.WriteLine("You picked up a(n) " + commandWords[1]);
                                            Console.WriteLine();
                                            if (commandWords[1] == "ARMOR")
                                            {
                                                Tourist.MaxHealth += 2;
                                            }
                                            itemCount += 1;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Can't Pick Up, Your inventory is full");
                                        }
                                    }
                                    else if (userNumber == Archaeologist.CharacterNumber)
                                    {
                                        if (itemCount + 1 <= Archaeologist.ItemLimit)
                                        {
                                            inventory.Add(RoomClass[currentRoom].roomItem.Find(item => item.ItemName == commandWords[1]));
                                            RoomClass[currentRoom].roomItem.Remove(RoomClass[currentRoom].roomItem.Find(item => item.ItemName == commandWords[1]));
                                            Console.WriteLine("You picked up a(n) " + commandWords[1]);
                                            Console.WriteLine();
                                            if (commandWords[1] == "ARMOR")
                                            {
                                                Archaeologist.MaxHealth += 2;
                                            }
                                            itemCount += 1;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Can't Pick Up, Your inventory is full");
                                        }
                                    }
                                    else if (userNumber == HomeDesigner.CharacterNumber)
                                    {
                                        if (itemCount + 1 <= HomeDesigner.ItemLimit)
                                        {
                                            inventory.Add(RoomClass[currentRoom].roomItem.Find(item => item.ItemName == commandWords[1]));
                                            RoomClass[currentRoom].roomItem.Remove(RoomClass[currentRoom].roomItem.Find(item => item.ItemName == commandWords[1]));
                                            Console.WriteLine("You picked up a(n) " + commandWords[1]);
                                            Console.WriteLine();
                                            if (commandWords[1] == "ARMOR")
                                            {
                                                HomeDesigner.MaxHealth += 2;
                                            }
                                            itemCount += 1;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Can't Pick Up, Your inventory is full");
                                        }
                                    }
                                    else if (userNumber == Soldier.CharacterNumber)
                                    {
                                        if (itemCount + 1 <= Soldier.ItemLimit)
                                        {
                                            inventory.Add(RoomClass[currentRoom].roomItem.Find(item => item.ItemName == commandWords[1]));
                                            RoomClass[currentRoom].roomItem.Remove(RoomClass[currentRoom].roomItem.Find(item => item.ItemName == commandWords[1]));
                                            Console.WriteLine("You picked up a(n) " + commandWords[1]);
                                            Console.WriteLine();
                                            if (commandWords[1] == "ARMOR")
                                            {
                                                Soldier.MaxHealth += 2;
                                            }
                                            itemCount += 1;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Can't Pick Up, Your inventory is full");
                                        }
                                    }
                                    else if (userNumber == NativeChild.CharacterNumber)
                                    {
                                        if (itemCount + 1 <= NativeChild.ItemLimit)
                                        {
                                            inventory.Add(RoomClass[currentRoom].roomItem.Find(item => item.ItemName == commandWords[1]));
                                            RoomClass[currentRoom].roomItem.Remove(RoomClass[currentRoom].roomItem.Find(item => item.ItemName == commandWords[1]));
                                            Console.WriteLine("You picked up a(n) " + commandWords[1]);
                                            Console.WriteLine();
                                            if (commandWords[1] == "ARMOR")
                                            {
                                                NativeChild.MaxHealth += 2;
                                            }
                                            itemCount += 1;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Can't Pick Up, Your inventory is full");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Cant pick that up. You already have a(n) " + commandWords[1] + " in your bag");
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("I do not see a " + commandWords[1] + " here!");
                            Console.WriteLine();
                        }
                    }
                    if (commandWords[0] == "DROP")
                    {
                        if (inventory.FindIndex(item => item.ItemName == commandWords[1]) >= 0)
                        {
                            RoomClass[currentRoom].roomItem.Add(inventory.Find(item => item.ItemName == commandWords[1]));
                            inventory.Remove(inventory.Find(item => item.ItemName == commandWords[1]));
                            itemCount -= 1;
                            if (commandWords[1] == "ARMOR")
                            {
                                if (userNumber == Tourist.CharacterNumber)
                                {
                                    Tourist.MaxHealth -= 2;
                                }
                                else if (userNumber == Archaeologist.CharacterNumber)
                                {
                                    Archaeologist.MaxHealth -= 2;
                                }
                                else if (userNumber == HomeDesigner.CharacterNumber)
                                {
                                    HomeDesigner.MaxHealth -= 2;
                                }
                                else if (userNumber == Soldier.CharacterNumber)
                                {
                                    Soldier.MaxHealth -= 2;
                                }
                                else if (userNumber == NativeChild.CharacterNumber)
                                {
                                    NativeChild.MaxHealth -= 2;
                                }
                            }
                            Console.WriteLine("You dropped the " + commandWords[1]);

                        }
                        else
                        {
                            Console.WriteLine("There is not a " + commandWords[1] + "in your inventory!");
                            Console.WriteLine();

                        }
                    }
                    else if (commandWords[0] == "GO")
                    {
                        if (commandWords[1] == "N" && RoomClass[currentRoom].ToNorth > 0 && RoomClass[currentRoom].ToNorth < 100 ||
                            commandWords[1] == "NORTH" && RoomClass[currentRoom].ToNorth > 0 && RoomClass[currentRoom].ToNorth < 100)
                        {
                            currentRoom = RoomClass[currentRoom].ToNorth;
                            Console.WriteLine();
                        }
                        else if (commandWords[1] == "E" && RoomClass[currentRoom].ToEast > 0 && RoomClass[currentRoom].ToEast < 100 ||
                            commandWords[1] == "EAST" && RoomClass[currentRoom].ToEast > 0 && RoomClass[currentRoom].ToEast < 100)
                        {
                            currentRoom = RoomClass[currentRoom].ToEast;
                            Console.WriteLine();

                        }
                        else if (commandWords[1] == "S" && RoomClass[currentRoom].ToSouth > 0 && RoomClass[currentRoom].ToSouth < 100 ||
                            commandWords[1] == "SOUTH" && RoomClass[currentRoom].ToSouth > 0 && RoomClass[currentRoom].ToSouth < 100)
                        {
                            currentRoom = RoomClass[currentRoom].ToSouth;
                            Console.WriteLine();

                        }
                        else if (commandWords[1] == "W" && RoomClass[currentRoom].ToWest > 0 && RoomClass[currentRoom].ToWest < 100 ||
                            commandWords[1] == "WEST" && RoomClass[currentRoom].ToWest > 0 && RoomClass[currentRoom].ToWest < 100)
                        {
                            currentRoom = RoomClass[currentRoom].ToWest;
                            Console.WriteLine();

                        }
                        else if (commandWords[1] == "U" && RoomClass[currentRoom].ToUp > 0 && RoomClass[currentRoom].ToUp < 100 ||
                            commandWords[1] == "UP" && RoomClass[currentRoom].ToUp > 0 && RoomClass[currentRoom].ToUp < 100)
                        {
                            currentRoom = RoomClass[currentRoom].ToUp;
                            Console.WriteLine();

                        }
                        else if (commandWords[1] == "D" && RoomClass[currentRoom].ToDown > 0 && RoomClass[currentRoom].ToDown < 100 ||
                            commandWords[1] == "DOWN" && RoomClass[currentRoom].ToDown > 0 && RoomClass[currentRoom].ToDown < 100)
                        {
                            currentRoom = RoomClass[currentRoom].ToDown;
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Sorry, You can't go that way ");
                            Console.WriteLine();
                        }

                    }
                    else if (commandWords[0] == "INFO" && commandWords[1] == "SHOVEL")
                    {
                        Console.WriteLine();
                        Console.WriteLine("SHOVEL: Useful For Digging");
                        Console.WriteLine();

                    }
                    foreach (ItemClass item in inventory)
                    {
                        if (item.ItemNumber == 101)
                        {
                            win = true;
                            commandWords[0] = "Q";
                        }
                        else
                        {
                            win = false;
                        }
                    }

                    if( lose == true)
                    {
                        command = "Q";
                    }
                }
            } while (commandWords[0] != "Q" );

            if (commandWords[0] == "Q" && win == true)
            {
                Console.WriteLine();
                Console.WriteLine("Congrats, you got the Golden Blizing! You won :)");
            }
            else if( lose == true && commandWords[0] == "Q")
            {
                Console.WriteLine();
                Console.WriteLine("Darn, you lost. Try again maybe");
            }
            else
            {
                Console.WriteLine("Sorry to see you go. Hope you had fun");
            }

            Console.ReadKey();
        }

        private static string GetName()
        {
            string Name = "";
            Console.ForegroundColor = ConsoleColor.Blue;
            string b = " What would you like to be named: ";
            Console.SetCursorPosition((Console.WindowWidth - b.Length) / 2, Console.CursorTop);
            Console.WriteLine(b);
            Console.ResetColor();

            Console.Write("                                                       ");
            Name = Console.ReadLine();
            return Name;
        }
        private static int EnterAnInt()
        {
            int inputInt = 0;

            try
            {

                inputInt = Int32.Parse(Console.ReadLine());


            }
            catch
            {
                Console.WriteLine("Needs to be a whole number!");

            }
            return inputInt;
        }

    }
}
