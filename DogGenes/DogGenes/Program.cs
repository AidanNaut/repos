using System;

namespace DogGenetics
{
    class Program
    {
        static void Main(string[] args)
        {
            // array of possible dog breeds.
            string[] dogBreeds = new string[]
            {
                "Golden Retriever", "Border Collie", "Pomeranian", "Pug", "Sheltie",
                "Chihuahua", "Boxer", "Pitbull", "Great Dane", "Poodle", "Yorkie",
                "Doberman", "St. Bernard"
            };

            // settings some variables.
            Random random = new Random();
            int maxDNA = 100;
            int rdmDNA;


            // determine number of possible breeds, up to 5.
            int rdmBreeds = random.Next(6);

            if (rdmBreeds == 0)
            {
                rdmBreeds = 1;
            }

            // build arrays based on possible breed number
            int[] percDNAArray = new int[rdmBreeds];
            string[] breedsArray = new string[rdmBreeds];
            
            for (int i = 0; i < rdmBreeds; i++)
            {
                // assign breed randomly
                breedsArray[i] = dogBreeds[random.Next(dogBreeds.Length)];
                // if determining last breed, set percentage to maxDNA - totalDNA, 
                // else determine percentage of DNA randomly,
                // add that percentage to totalDNA, subtract that percentage from maxDNA
                if (i == rdmBreeds - 1)
                {
                    percDNAArray[i] = maxDNA;
                    break;
                }
                rdmDNA = random.Next(maxDNA);

                while (true)
                {
                    if (rdmDNA == 0)
                    {
                        rdmDNA = random.Next(maxDNA);
                    }
                    else
                    {
                        break;
                    }
                }

                percDNAArray[i] = rdmDNA;
                maxDNA -= rdmDNA;
            }

            for (int i = 0; i < rdmBreeds; i++)
            {
                Console.WriteLine(breedsArray[i] + percDNAArray[i]);
            }

            Console.ReadLine();

        }
    }
}
