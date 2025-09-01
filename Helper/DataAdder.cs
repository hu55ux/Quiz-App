using QuizGame.Entities;
using QuizGame.Services;

namespace QuizGame.Helper;

public class DataAdder : BaseService
{
    public DataAdder(QuizGameDBContext database) : base(database)
    {
    }

    public void SeedDataAdding()
    {
        _database.Users.AddRange(users);
        _database.Quizzes.AddRange(quizHistory, geographyQuiz, biologyQuiz, mixedQuiz);
        _database.SaveChanges();
        var results = new List<Result>();

        var allUsers = _database.Users.ToList();
        var allQuizzes = _database.Quizzes.ToList();

        foreach (var user in allUsers)
        {
            foreach (var quiz in allQuizzes)
            {
                int score = new Random().Next(10, 21);
                results.Add(new Result
                {
                    UserId = user.Id,
                    QuizId = quiz.Id,
                    Score = score
                });
            }
        }

        _database.Results.AddRange(results);
        _database.SaveChanges();
    }


    public Quiz quizHistory = new Quiz
    {
        Title = "History Quiz",
        Category = QuizCategory.History,
        Questions = new List<Question>
    {
        new Question
        {
            Text = "In which year did World War II end?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "1943", IsCorrect = false },
                new Answer { Text = "1945", IsCorrect = true },
                new Answer { Text = "1950", IsCorrect = false },
                new Answer { Text = "1939", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Who was the first president of the United States?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Thomas Jefferson", IsCorrect = false },
                new Answer { Text = "John Adams", IsCorrect = false },
                new Answer { Text = "George Washington", IsCorrect = true },
                new Answer { Text = "Abraham Lincoln", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which ancient civilization built the pyramids?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Greeks", IsCorrect = false },
                new Answer { Text = "Romans", IsCorrect = false },
                new Answer { Text = "Egyptians", IsCorrect = true },
                new Answer { Text = "Mayans", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which of these events happened during the Middle Ages?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "The Crusades", IsCorrect = true },
                new Answer { Text = "The American Revolution", IsCorrect = false },
                new Answer { Text = "World War I", IsCorrect = false },
                new Answer { Text = "The Industrial Revolution", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which countries were part of the Axis powers in WWII?",
            isMultipleChoice = true,
            Answers = new List<Answer>
            {
                new Answer { Text = "Germany", IsCorrect = true },
                new Answer { Text = "Italy", IsCorrect = true },
                new Answer { Text = "Japan", IsCorrect = true },
                new Answer { Text = "United States", IsCorrect = false },
                new Answer { Text = "France", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "The Renaissance began in which country?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "France", IsCorrect = false },
                new Answer { Text = "England", IsCorrect = false },
                new Answer { Text = "Italy", IsCorrect = true },
                new Answer { Text = "Spain", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Who wrote the 95 Theses?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "John Calvin", IsCorrect = false },
                new Answer { Text = "Martin Luther", IsCorrect = true },
                new Answer { Text = "Henry VIII", IsCorrect = false },
                new Answer { Text = "Pope Leo X", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "The Industrial Revolution began in which country?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "United States", IsCorrect = false },
                new Answer { Text = "France", IsCorrect = false },
                new Answer { Text = "Germany", IsCorrect = false },
                new Answer { Text = "Great Britain", IsCorrect = true }
            }
        },
        new Question
        {
            Text = "Which ancient wonder was located in Babylon?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Great Pyramid", IsCorrect = false },
                new Answer { Text = "Hanging Gardens", IsCorrect = true },
                new Answer { Text = "Colossus of Rhodes", IsCorrect = false },
                new Answer { Text = "Lighthouse of Alexandria", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "The Magna Carta was signed in which year?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "1066", IsCorrect = false },
                new Answer { Text = "1215", IsCorrect = true },
                new Answer { Text = "1492", IsCorrect = false },
                new Answer { Text = "1776", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Who was the leader of the Soviet Union during WWII?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Vladimir Lenin", IsCorrect = false },
                new Answer { Text = "Joseph Stalin", IsCorrect = true },
                new Answer { Text = "Nikita Khrushchev", IsCorrect = false },
                new Answer { Text = "Leon Trotsky", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which civilization invented paper?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Ancient Egyptians", IsCorrect = false },
                new Answer { Text = "Ancient Chinese", IsCorrect = true },
                new Answer { Text = "Ancient Greeks", IsCorrect = false },
                new Answer { Text = "Ancient Romans", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "The French Revolution began in which year?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "1776", IsCorrect = false },
                new Answer { Text = "1789", IsCorrect = true },
                new Answer { Text = "1812", IsCorrect = false },
                new Answer { Text = "1688", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which explorer reached India by sea?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Christopher Columbus", IsCorrect = false },
                new Answer { Text = "Vasco da Gama", IsCorrect = true },
                new Answer { Text = "Ferdinand Magellan", IsCorrect = false },
                new Answer { Text = "Marco Polo", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "The Berlin Wall fell in which year?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "1985", IsCorrect = false },
                new Answer { Text = "1989", IsCorrect = true },
                new Answer { Text = "1991", IsCorrect = false },
                new Answer { Text = "1975", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Who was the first female pharaoh of Egypt?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Nefertiti", IsCorrect = false },
                new Answer { Text = "Cleopatra", IsCorrect = false },
                new Answer { Text = "Hatshepsut", IsCorrect = true },
                new Answer { Text = "Merneith", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which empire was ruled by Suleiman the Magnificent?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Roman Empire", IsCorrect = false },
                new Answer { Text = "Ottoman Empire", IsCorrect = true },
                new Answer { Text = "British Empire", IsCorrect = false },
                new Answer { Text = "Mongol Empire", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "The Declaration of Independence was signed in which year?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "1776", IsCorrect = true },
                new Answer { Text = "1789", IsCorrect = false },
                new Answer { Text = "1799", IsCorrect = false },
                new Answer { Text = "1812", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which ancient city was destroyed by a volcanic eruption?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Athens", IsCorrect = false },
                new Answer { Text = "Pompeii", IsCorrect = true },
                new Answer { Text = "Troy", IsCorrect = false },
                new Answer { Text = "Carthage", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Who invented the printing press?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Leonardo da Vinci", IsCorrect = false },
                new Answer { Text = "Galileo Galilei", IsCorrect = false },
                new Answer { Text = "Johannes Gutenberg", IsCorrect = true },
                new Answer { Text = "Isaac Newton", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "The Hundred Years' War was between which two countries?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "England and France", IsCorrect = true },
                new Answer { Text = "Spain and Portugal", IsCorrect = false },
                new Answer { Text = "Germany and Italy", IsCorrect = false },
                new Answer { Text = "Russia and Poland", IsCorrect = false }
        }
        },
        new Question
        {
            Text = "Which Chinese dynasty built the Great Wall?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
            new Answer { Text = "Han", IsCorrect = false },
            new Answer { Text = "Tang", IsCorrect = false },
            new Answer { Text = "Ming", IsCorrect = false },
            new Answer { Text = "Qin", IsCorrect = true }
            }
        },
        new Question
        {
        Text = "The Treaty of Versailles ended which war?",
        isMultipleChoice = false,
        Answers = new List<Answer>
        {
            new Answer { Text = "World War I", IsCorrect = true },
            new Answer { Text = "World War II", IsCorrect = false },
            new Answer { Text = "Napoleonic Wars", IsCorrect = false },
            new Answer { Text = "Franco-Prussian War", IsCorrect = false }
        }
        },
        new Question
        {
            Text = "Who was the first emperor of Rome?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Julius Caesar", IsCorrect = false },
                new Answer { Text = "Augustus", IsCorrect = true },
                new Answer { Text = "Nero", IsCorrect = false },
                new Answer { Text = "Constantine", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "The Silk Road connected which regions?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Europe and Africa", IsCorrect = false },
                new Answer { Text = "Europe and Asia", IsCorrect = true },
                new Answer { Text = "Asia and Africa", IsCorrect = false },
                new Answer { Text = "America and Asia", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which country was not part of the Allied powers in WWII?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "United States", IsCorrect = false },
                new Answer { Text = "Soviet Union", IsCorrect = false },
                new Answer { Text = "Germany", IsCorrect = true },
                new Answer { Text = "Great Britain", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "The Black Death occurred during which century?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "12th", IsCorrect = false },
                new Answer { Text = "14th", IsCorrect = true },
                new Answer { Text = "16th", IsCorrect = false },
                new Answer { Text = "18th", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Who was the first European to reach North America?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Christopher Columbus", IsCorrect = false },
                new Answer { Text = "Leif Erikson", IsCorrect = true },
                new Answer { Text = "John Cabot", IsCorrect = false },
                new Answer { Text = "Amerigo Vespucci", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "The Cold War was primarily between which two countries?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "USA and China", IsCorrect = false },
                new Answer { Text = "USA and Soviet Union", IsCorrect = true },
                new Answer { Text = "China and Soviet Union", IsCorrect = false },
                new Answer { Text = "USA and Germany", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which civilization invented democracy?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Ancient Romans", IsCorrect = false },
                new Answer { Text = "Ancient Egyptians", IsCorrect = false },
                new Answer { Text = "Ancient Greeks", IsCorrect = true },
                new Answer { Text = "Ancient Chinese", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "The American Civil War was fought between which years?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "1775-1783", IsCorrect = false },
                new Answer { Text = "1812-1815", IsCorrect = false },
                new Answer { Text = "1861-1865", IsCorrect = true },
                new Answer { Text = "1914-1918", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Who was the first female Prime Minister of the UK?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Queen Elizabeth I", IsCorrect = false },
                new Answer { Text = "Margaret Thatcher", IsCorrect = true },
                new Answer { Text = "Theresa May", IsCorrect = false },
                new Answer { Text = "Indira Gandhi", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "The Boxer Rebellion occurred in which country?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Japan", IsCorrect = false },
                new Answer { Text = "India", IsCorrect = false },
                new Answer { Text = "China", IsCorrect = true },
                new Answer { Text = "Vietnam", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which empire was ruled by Genghis Khan?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Persian Empire", IsCorrect = false },
                new Answer { Text = "Mongol Empire", IsCorrect = true },
                new Answer { Text = "Ottoman Empire", IsCorrect = false },
                new Answer { Text = "Roman Empire", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "The Spanish Armada was defeated by which country?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "France", IsCorrect = false },
                new Answer { Text = "Portugal", IsCorrect = false },
                new Answer { Text = "England", IsCorrect = true },
                new Answer { Text = "Netherlands", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which country was not part of the Triple Entente in WWI?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "France", IsCorrect = false },
                new Answer { Text = "Russia", IsCorrect = false },
                new Answer { Text = "Great Britain", IsCorrect = false },
                new Answer { Text = "Germany", IsCorrect = true }
            }
        },
        new Question
        {
            Text = "The first successful English colony in America was?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Plymouth", IsCorrect = false },
                new Answer { Text = "Jamestown", IsCorrect = true },
                new Answer { Text = "Roanoke", IsCorrect = false },
                new Answer { Text = "New Amsterdam", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which revolution began with the storming of the Bastille?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "American Revolution", IsCorrect = false },
                new Answer { Text = "French Revolution", IsCorrect = true },
                new Answer { Text = "Russian Revolution", IsCorrect = false },
                new Answer { Text = "Industrial Revolution", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "The first atomic bombs were dropped on which Japanese cities?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Tokyo and Kyoto", IsCorrect = false },
                new Answer { Text = "Hiroshima and Nagasaki", IsCorrect = true },
                new Answer { Text = "Osaka and Yokohama", IsCorrect = false },
                new Answer { Text = "Nagasaki and Tokyo", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which ancient civilization developed the concept of zero?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Egyptians", IsCorrect = false },
                new Answer { Text = "Greeks", IsCorrect = false },
                new Answer { Text = "Mayans", IsCorrect = false },
                new Answer { Text = "Indians", IsCorrect = true }
            }
        }
    }
    };

    public Quiz biologyQuiz = new Quiz
    {
        Title = "Biology Quiz",
        Category = QuizCategory.Biology, // Category = 2
        Questions = new List<Question>
    {
        new Question
        {
            Text = "What is the basic unit of life?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Atom", IsCorrect = false },
                new Answer { Text = "Cell", IsCorrect = true },
                new Answer { Text = "Molecule", IsCorrect = false },
                new Answer { Text = "Organ", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which of these is not one of the four main blood types?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "A", IsCorrect = false },
                new Answer { Text = "B", IsCorrect = false },
                new Answer { Text = "AB", IsCorrect = false },
                new Answer { Text = "C", IsCorrect = true }
            }
        },
        new Question
        {
            Text = "Photosynthesis occurs in which part of the plant cell?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Mitochondria", IsCorrect = false },
                new Answer { Text = "Nucleus", IsCorrect = false },
                new Answer { Text = "Chloroplast", IsCorrect = true },
                new Answer { Text = "Ribosome", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which of these is not a function of the liver?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Detoxification", IsCorrect = false },
                new Answer { Text = "Protein synthesis", IsCorrect = false },
                new Answer { Text = "Blood filtration", IsCorrect = false },
                new Answer { Text = "Insulin production", IsCorrect = true }
            }
        },
        new Question
        {
            Text = "Which of these are parts of a neuron?",
            isMultipleChoice = true,
            Answers = new List<Answer>
            {
                new Answer { Text = "Dendrite", IsCorrect = true },
                new Answer { Text = "Axon", IsCorrect = true },
                new Answer { Text = "Synapse", IsCorrect = true },
                new Answer { Text = "Nucleus", IsCorrect = false },
                new Answer { Text = "Myelin sheath", IsCorrect = true }
            }
        },
        new Question
        {
            Text = "The human body's largest organ is:",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Liver", IsCorrect = false },
                new Answer { Text = "Brain", IsCorrect = false },
                new Answer { Text = "Skin", IsCorrect = true },
                new Answer { Text = "Heart", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which of these is not a type of white blood cell?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Lymphocyte", IsCorrect = false },
                new Answer { Text = "Neutrophil", IsCorrect = false },
                new Answer { Text = "Erythrocyte", IsCorrect = true },
                new Answer { Text = "Monocyte", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "DNA stands for:",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Deoxyribonucleic acid", IsCorrect = true },
                new Answer { Text = "Denatured nucleic acid", IsCorrect = false },
                new Answer { Text = "Double nucleotide acid", IsCorrect = false },
                new Answer { Text = "Dual nitrogen acid", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which of these is not a kingdom in biological classification?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Animalia", IsCorrect = false },
                new Answer { Text = "Plantae", IsCorrect = false },
                new Answer { Text = "Fungi", IsCorrect = false },
                new Answer { Text = "Protista", IsCorrect = false },
                new Answer { Text = "Bacteria", IsCorrect = false },
                new Answer { Text = "Virus", IsCorrect = true }
            }
        },
        new Question
        {
            Text = "The process by which plants lose water through their leaves is called:",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Photosynthesis", IsCorrect = false },
                new Answer { Text = "Transpiration", IsCorrect = true },
                new Answer { Text = "Respiration", IsCorrect = false },
                new Answer { Text = "Evaporation", IsCorrect = false }
            }
        },
         new Question
        {
            Text = "Which of these is not a bone in the human body?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Femur", IsCorrect = false },
                new Answer { Text = "Tibia", IsCorrect = false },
                new Answer { Text = "Radius", IsCorrect = false },
                new Answer { Text = "Patella", IsCorrect = false },
                new Answer { Text = "Aorta", IsCorrect = true }
            }
        },
        new Question
        {
            Text = "The study of fungi is called:",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Mycology", IsCorrect = true },
                new Answer { Text = "Entomology", IsCorrect = false },
                new Answer { Text = "Botany", IsCorrect = false },
                new Answer { Text = "Virology", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which vitamin is produced when human skin is exposed to sunlight?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Vitamin A", IsCorrect = false },
                new Answer { Text = "Vitamin B12", IsCorrect = false },
                new Answer { Text = "Vitamin C", IsCorrect = false },
                new Answer { Text = "Vitamin D", IsCorrect = true }
            }
        },
        new Question
        {
            Text = "The smallest blood vessels in the human body are called:",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Arteries", IsCorrect = false },
                new Answer { Text = "Veins", IsCorrect = false },
                new Answer { Text = "Capillaries", IsCorrect = true },
                new Answer { Text = "Venules", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which part of the brain controls balance and coordination?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Cerebrum", IsCorrect = false },
                new Answer { Text = "Cerebellum", IsCorrect = true },
                new Answer { Text = "Medulla oblongata", IsCorrect = false },
                new Answer { Text = "Hypothalamus", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "The process by which cells divide to create two identical daughter cells is called:",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Meiosis", IsCorrect = false },
                new Answer { Text = "Mitosis", IsCorrect = true },
                new Answer { Text = "Binary fission", IsCorrect = false },
                new Answer { Text = "Budding", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which of these is not a type of muscle tissue?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Skeletal", IsCorrect = false },
                new Answer { Text = "Cardiac", IsCorrect = false },
                new Answer { Text = "Smooth", IsCorrect = false },
                new Answer { Text = "Elastic", IsCorrect = true }
            }
        },
        new Question
        {
            Text = "The largest part of the human brain is the:",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Cerebrum", IsCorrect = true },
                new Answer { Text = "Cerebellum", IsCorrect = false },
                new Answer { Text = "Brain stem", IsCorrect = false },
                new Answer { Text = "Thalamus", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which of these is not a function of the skeletal system?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Support", IsCorrect = false },
                new Answer { Text = "Protection", IsCorrect = false },
                new Answer { Text = "Movement", IsCorrect = false },
                new Answer { Text = "Hormone production", IsCorrect = true }
            }
        },
        new Question
        {
            Text = "The process by which plants make food using sunlight is called:",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Respiration", IsCorrect = false },
                new Answer { Text = "Transpiration", IsCorrect = false },
                new Answer { Text = "Photosynthesis", IsCorrect = true },
                new Answer { Text = "Fermentation", IsCorrect = false }
            }
        },
            new Question
        {
            Text = "Which of these is not a component of the central nervous system?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Brain", IsCorrect = false },
                new Answer { Text = "Spinal cord", IsCorrect = false },
                new Answer { Text = "Nerves", IsCorrect = true },
                new Answer { Text = "Neurons", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "The hormone insulin is produced by which organ?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Liver", IsCorrect = false },
                new Answer { Text = "Pancreas", IsCorrect = true },
                new Answer { Text = "Kidney", IsCorrect = false },
                new Answer { Text = "Stomach", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which of these is not a type of RNA?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "mRNA", IsCorrect = false },
                new Answer { Text = "tRNA", IsCorrect = false },
                new Answer { Text = "rRNA", IsCorrect = false },
                new Answer { Text = "dRNA", IsCorrect = true }
            }
        },
        new Question
        {
            Text = "The study of insects is called:",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Ornithology", IsCorrect = false },
                new Answer { Text = "Entomology", IsCorrect = true },
                new Answer { Text = "Herpetology", IsCorrect = false },
                new Answer { Text = "Ichthyology", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which of these is not a function of the kidneys?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Filter blood", IsCorrect = false },
                new Answer { Text = "Produce urine", IsCorrect = false },
                new Answer { Text = "Regulate blood pressure", IsCorrect = false },
                new Answer { Text = "Produce bile", IsCorrect = true }
            }
        },
        new Question
        {
            Text = "The smallest unit of an element is called:",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Molecule", IsCorrect = false },
                new Answer { Text = "Atom", IsCorrect = true },
                new Answer { Text = "Cell", IsCorrect = false },
                new Answer { Text = "Compound", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which of these is not a type of joint in the human body?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Hinge", IsCorrect = false },
                new Answer { Text = "Ball and socket", IsCorrect = false },
                new Answer { Text = "Pivot", IsCorrect = false },
                new Answer { Text = "Elastic", IsCorrect = true }
            }
        },
        new Question
        {
            Text = "The process by which plants respond to light is called:",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Gravitropism", IsCorrect = false },
                new Answer { Text = "Phototropism", IsCorrect = true },
                new Answer { Text = "Thigmotropism", IsCorrect = false },
                new Answer { Text = "Hydrotropism", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which of these is not a primary taste sensation?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Sweet", IsCorrect = false },
                new Answer { Text = "Sour", IsCorrect = false },
                new Answer { Text = "Salty", IsCorrect = false },
                new Answer { Text = "Bitter", IsCorrect = false },
                new Answer { Text = "Umami", IsCorrect = false },
                new Answer { Text = "Spicy", IsCorrect = true }
            }
        },
        new Question
        {
            Text = "The largest artery in the human body is the:",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Pulmonary artery", IsCorrect = false },
                new Answer { Text = "Aorta", IsCorrect = true },
                new Answer { Text = "Coronary artery", IsCorrect = false },
                new Answer { Text = "Jugular vein", IsCorrect = false }
            }
        },
            new Question
        {
            Text = "Which of these is not a function of the respiratory system?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Gas exchange", IsCorrect = false },
                new Answer { Text = "pH regulation", IsCorrect = false },
                new Answer { Text = "Sound production", IsCorrect = false },
                new Answer { Text = "Nutrient absorption", IsCorrect = true }
            }
        },
        new Question
        {
            Text = "The process by which water moves across a semipermeable membrane is called:",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Diffusion", IsCorrect = false },
                new Answer { Text = "Osmosis", IsCorrect = true },
                new Answer { Text = "Active transport", IsCorrect = false },
                new Answer { Text = "Facilitated diffusion", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which of these is not a type of plant tissue?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Epidermal", IsCorrect = false },
                new Answer { Text = "Ground", IsCorrect = false },
                new Answer { Text = "Vascular", IsCorrect = false },
                new Answer { Text = "Muscular", IsCorrect = true }
            }
        },
        new Question
        {
            Text = "The study of animal behavior is called:",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Ecology", IsCorrect = false },
                new Answer { Text = "Ethology", IsCorrect = true },
                new Answer { Text = "Zoology", IsCorrect = false },
                new Answer { Text = "Psychology", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which of these is not a function of the lymphatic system?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Fluid balance", IsCorrect = false },
                new Answer { Text = "Immune defense", IsCorrect = false },
                new Answer { Text = "Fat absorption", IsCorrect = false },
                new Answer { Text = "Oxygen transport", IsCorrect = true }
            }
        },
        new Question
        {
            Text = "The process by which plants grow toward gravity is called:",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Phototropism", IsCorrect = false },
                new Answer { Text = "Gravitropism", IsCorrect = true },
                new Answer { Text = "Thigmotropism", IsCorrect = false },
                new Answer { Text = "Hydrotropism", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which of these is not a function of the integumentary system?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Protection", IsCorrect = false },
                new Answer { Text = "Temperature regulation", IsCorrect = false },
                new Answer { Text = "Sensation", IsCorrect = false },
                new Answer { Text = "Hormone production", IsCorrect = true }
            }
        },
        new Question
        {
            Text = "The study of fish is called:",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Ornithology", IsCorrect = false },
                new Answer { Text = "Herpetology", IsCorrect = false },
                new Answer { Text = "Ichthyology", IsCorrect = true },
                new Answer { Text = "Mammalogy", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which of these is not a function of the cardiovascular system?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Transport oxygen", IsCorrect = false },
                new Answer { Text = "Transport nutrients", IsCorrect = false },
                new Answer { Text = "Remove waste", IsCorrect = false },
                new Answer { Text = "Produce hormones", IsCorrect = true }
            }
        },
        new Question
        {
            Text = "The process by which cells engulf large particles is called:",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Diffusion", IsCorrect = false },
                new Answer { Text = "Osmosis", IsCorrect = false },
                new Answer { Text = "Phagocytosis", IsCorrect = true },
                new Answer { Text = "Pinocytosis", IsCorrect = false }
            }
        }

    }
    };

    public Quiz geographyQuiz = new Quiz
    {
        Title = "Geography Quiz",
        Category = QuizCategory.Geography, // 1 üçün enum dəyəri
        Questions = new List<Question>
    {
        new Question
        {
            Text = "What is the capital of France?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Berlin", IsCorrect = false },
                new Answer { Text = "Madrid", IsCorrect = false },
                new Answer { Text = "Paris", IsCorrect = true },
                new Answer { Text = "Rome", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which is the longest river in the world?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Amazon", IsCorrect = false },
                new Answer { Text = "Nile", IsCorrect = true },
                new Answer { Text = "Yangtze", IsCorrect = false },
                new Answer { Text = "Mississippi", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Mount Everest is located in which mountain range?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Andes", IsCorrect = false },
                new Answer { Text = "Alps", IsCorrect = false },
                new Answer { Text = "Himalayas", IsCorrect = true },
                new Answer { Text = "Rockies", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which of these countries is landlocked?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Brazil", IsCorrect = false },
                new Answer { Text = "Australia", IsCorrect = false },
                new Answer { Text = "Switzerland", IsCorrect = true },
                new Answer { Text = "Japan", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which countries share a border with the United States?",
            isMultipleChoice = true,
            Answers = new List<Answer>
            {
                new Answer { Text = "Canada", IsCorrect = true },
                new Answer { Text = "Mexico", IsCorrect = true },
                new Answer { Text = "Russia", IsCorrect = false },
                new Answer { Text = "Cuba", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "The Sahara Desert is located in which continent?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Asia", IsCorrect = false },
                new Answer { Text = "Africa", IsCorrect = true },
                new Answer { Text = "South America", IsCorrect = false },
                new Answer { Text = "Australia", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which of these is the largest ocean?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Atlantic", IsCorrect = false },
                new Answer { Text = "Indian", IsCorrect = false },
                new Answer { Text = "Arctic", IsCorrect = false },
                new Answer { Text = "Pacific", IsCorrect = true }
            }
        },
        new Question
        {
            Text = "The Great Barrier Reef is located off the coast of which country?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Brazil", IsCorrect = false },
                new Answer { Text = "Australia", IsCorrect = true },
                new Answer { Text = "Indonesia", IsCorrect = false },
                new Answer { Text = "South Africa", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which continent contains the most fresh water?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Asia", IsCorrect = false },
                new Answer { Text = "Africa", IsCorrect = false },
                new Answer { Text = "Antarctica", IsCorrect = true },
                new Answer { Text = "North America", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "The Amazon rainforest is primarily located in which country?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Brazil", IsCorrect = true },
                new Answer { Text = "Peru", IsCorrect = false },
                new Answer { Text = "Colombia", IsCorrect = false },
                new Answer { Text = "Venezuela", IsCorrect = false }
            }
        },
                new Question
        {
            Text = "Which of these cities is not a national capital?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Sydney", IsCorrect = true },
                new Answer { Text = "Canberra", IsCorrect = false },
                new Answer { Text = "Washington D.C.", IsCorrect = false },
                new Answer { Text = "London", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "The Dead Sea is bordered by which countries?",
            isMultipleChoice = true,
            Answers = new List<Answer>
            {
                new Answer { Text = "Israel", IsCorrect = true },
                new Answer { Text = "Jordan", IsCorrect = true },
                new Answer { Text = "Egypt", IsCorrect = false },
                new Answer { Text = "Syria", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which country has the most time zones?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "United States", IsCorrect = false },
                new Answer { Text = "Russia", IsCorrect = false },
                new Answer { Text = "China", IsCorrect = false },
                new Answer { Text = "Canada", IsCorrect = false },
                new Answer { Text = "France", IsCorrect = true } // düzəliş JSON-da göstərilib
            }
        },
        new Question
        {
            Text = "The Panama Canal connects which two oceans?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Atlantic and Indian", IsCorrect = false },
                new Answer { Text = "Atlantic and Pacific", IsCorrect = true },
                new Answer { Text = "Pacific and Indian", IsCorrect = false },
                new Answer { Text = "Arctic and Atlantic", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which of these is the smallest country by area?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Monaco", IsCorrect = false },
                new Answer { Text = "Vatican City", IsCorrect = true },
                new Answer { Text = "San Marino", IsCorrect = false },
                new Answer { Text = "Liechtenstein", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "The Yangtze River is located in which country?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "India", IsCorrect = false },
                new Answer { Text = "China", IsCorrect = true },
                new Answer { Text = "Japan", IsCorrect = false },
                new Answer { Text = "Vietnam", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which African country was formerly known as Abyssinia?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Ethiopia", IsCorrect = true },
                new Answer { Text = "Sudan", IsCorrect = false },
                new Answer { Text = "Kenya", IsCorrect = false },
                new Answer { Text = "Tanzania", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "The Ural Mountains form a boundary between which two continents?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Europe and Asia", IsCorrect = true },
                new Answer { Text = "Asia and Africa", IsCorrect = false },
                new Answer { Text = "North and South America", IsCorrect = false },
                new Answer { Text = "Europe and Africa", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which country is known as the 'Land of the Rising Sun'?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "China", IsCorrect = false },
                new Answer { Text = "Japan", IsCorrect = true },
                new Answer { Text = "South Korea", IsCorrect = false },
                new Answer { Text = "Thailand", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "The capital of Canada is:",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Toronto", IsCorrect = false },
                new Answer { Text = "Vancouver", IsCorrect = false },
                new Answer { Text = "Ottawa", IsCorrect = true }
            }
        },
            new Question
        {
            Text = "Which of these countries is not in Europe?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Hungary", IsCorrect = false },
                new Answer { Text = "Romania", IsCorrect = false },
                new Answer { Text = "Morocco", IsCorrect = true },
                new Answer { Text = "Poland", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "The Galapagos Islands belong to which country?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Ecuador", IsCorrect = true },
                new Answer { Text = "Peru", IsCorrect = false },
                new Answer { Text = "Chile", IsCorrect = false },
                new Answer { Text = "Colombia", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which of these cities is located in both Europe and Asia?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Istanbul", IsCorrect = true },
                new Answer { Text = "Moscow", IsCorrect = false },
                new Answer { Text = "Cairo", IsCorrect = false },
                new Answer { Text = "Dubai", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "The Atacama Desert is located in which continent?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Africa", IsCorrect = false },
                new Answer { Text = "Asia", IsCorrect = false },
                new Answer { Text = "South America", IsCorrect = true },
                new Answer { Text = "Australia", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which country is both an island and a continent?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "New Zealand", IsCorrect = false },
                new Answer { Text = "Madagascar", IsCorrect = false },
                new Answer { Text = "Australia", IsCorrect = true },
                new Answer { Text = "Greenland", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "The Strait of Gibraltar separates which two landmasses?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Europe and Africa", IsCorrect = true },
                new Answer { Text = "Asia and Europe", IsCorrect = false },
                new Answer { Text = "North and South America", IsCorrect = false },
                new Answer { Text = "Africa and Asia", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which of these is the largest country by area?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Canada", IsCorrect = false },
                new Answer { Text = "China", IsCorrect = false },
                new Answer { Text = "United States", IsCorrect = false },
                new Answer { Text = "Brazil", IsCorrect = false },
                new Answer { Text = "Russia", IsCorrect = true }
            }
        },
        new Question
        {
            Text = "The capital of Australia is:",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Sydney", IsCorrect = false },
                new Answer { Text = "Melbourne", IsCorrect = false },
                new Answer { Text = "Canberra", IsCorrect = true },
                new Answer { Text = "Brisbane", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which river runs through Baghdad?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Nile", IsCorrect = false },
                new Answer { Text = "Tigris", IsCorrect = true },
                new Answer { Text = "Euphrates", IsCorrect = false },
                new Answer { Text = "Jordan", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "The Andes mountain range runs through which countries?",
            isMultipleChoice = true,
            Answers = new List<Answer>
            {
                new Answer { Text = "Chile", IsCorrect = true },
                new Answer { Text = "Peru", IsCorrect = true },
                new Answer { Text = "Colombia", IsCorrect = true },
                new Answer { Text = "Brazil", IsCorrect = false },
                new Answer { Text = "Argentina", IsCorrect = true }
            }
        },
            new Question
        {
            Text = "Which of these is not a Scandinavian country?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Sweden", IsCorrect = false },
                new Answer { Text = "Finland", IsCorrect = true },
                new Answer { Text = "Denmark", IsCorrect = false },
                new Answer { Text = "Iceland", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "The Suez Canal connects which two bodies of water?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Mediterranean Sea and Red Sea", IsCorrect = true },
                new Answer { Text = "Atlantic and Pacific", IsCorrect = false },
                new Answer { Text = "Indian Ocean and Persian Gulf", IsCorrect = false },
                new Answer { Text = "Black Sea and Aegean Sea", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which country has the longest coastline?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Russia", IsCorrect = false },
                new Answer { Text = "Canada", IsCorrect = true },
                new Answer { Text = "United States", IsCorrect = false },
                new Answer { Text = "Australia", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "The Maldives are located in which ocean?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Atlantic", IsCorrect = false },
                new Answer { Text = "Indian", IsCorrect = true },
                new Answer { Text = "Pacific", IsCorrect = false },
                new Answer { Text = "Arctic", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which of these US states does not border Mexico?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Texas", IsCorrect = false },
                new Answer { Text = "Arizona", IsCorrect = false },
                new Answer { Text = "New Mexico", IsCorrect = false },
                new Answer { Text = "Nevada", IsCorrect = true }
            }
        },
        new Question
        {
            Text = "The capital of South Africa is:",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Johannesburg", IsCorrect = false },
                new Answer { Text = "Cape Town", IsCorrect = false },
                new Answer { Text = "Pretoria", IsCorrect = true },
                new Answer { Text = "Durban", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which of these is not a Baltic state?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Estonia", IsCorrect = false },
                new Answer { Text = "Latvia", IsCorrect = false },
                new Answer { Text = "Lithuania", IsCorrect = false },
                new Answer { Text = "Poland", IsCorrect = true }
            }
        },
        new Question
        {
            Text = "The highest mountain in Africa is:",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Mount Kenya", IsCorrect = false },
                new Answer { Text = "Mount Kilimanjaro", IsCorrect = true },
                new Answer { Text = "Mount Stanley", IsCorrect = false },
                new Answer { Text = "Mount Meru", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which of these countries is not in South America?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Suriname", IsCorrect = false },
                new Answer { Text = "Guyana", IsCorrect = false },
                new Answer { Text = "Belize", IsCorrect = true },
                new Answer { Text = "Ecuador", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "The largest island in the world is:",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Greenland", IsCorrect = true },
                new Answer { Text = "Australia", IsCorrect = false },
                new Answer { Text = "Borneo", IsCorrect = false },
                new Answer { Text = "Madagascar", IsCorrect = false }
            }
        }
    }
    };

    public Quiz mixedQuiz = new Quiz
    {
        Title = "Mixed Quiz",
        Category = QuizCategory.Mixed,
        Questions = new List<Question>
        {
        new Question
        {
            Text = "Which planet is known as the Red Planet?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Venus", IsCorrect = false },
                new Answer { Text = "Mars", IsCorrect = true },
                new Answer { Text = "Jupiter", IsCorrect = false },
                new Answer { Text = "Saturn", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Who painted the Mona Lisa?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Vincent van Gogh", IsCorrect = false },
                new Answer { Text = "Pablo Picasso", IsCorrect = false },
                new Answer { Text = "Leonardo da Vinci", IsCorrect = true },
                new Answer { Text = "Michelangelo", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which of these elements is a noble gas?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Oxygen", IsCorrect = false },
                new Answer { Text = "Nitrogen", IsCorrect = false },
                new Answer { Text = "Helium", IsCorrect = true },
                new Answer { Text = "Chlorine", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which Shakespeare play features the characters Romeo and Juliet?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Macbeth", IsCorrect = false },
                new Answer { Text = "Hamlet", IsCorrect = false },
                new Answer { Text = "Othello", IsCorrect = false },
                new Answer { Text = "Romeo and Juliet", IsCorrect = true }
            }
        },
        new Question
        {
            Text = "Which of these are primary colors of light?",
            isMultipleChoice = true,
            Answers = new List<Answer>
            {
                new Answer { Text = "Red", IsCorrect = true },
                new Answer { Text = "Blue", IsCorrect = true },
                new Answer { Text = "Green", IsCorrect = true },
                new Answer { Text = "Yellow", IsCorrect = false },
                new Answer { Text = "Cyan", IsCorrect = false },
                new Answer { Text = "Magenta", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which instrument measures atmospheric pressure?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Thermometer", IsCorrect = false },
                new Answer { Text = "Barometer", IsCorrect = true },
                new Answer { Text = "Hygrometer", IsCorrect = false },
                new Answer { Text = "Anemometer", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Who wrote 'To Kill a Mockingbird'?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Harper Lee", IsCorrect = true },
                new Answer { Text = "Mark Twain", IsCorrect = false },
                new Answer { Text = "J.D. Salinger", IsCorrect = false },
                new Answer { Text = "F. Scott Fitzgerald", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "What is the chemical symbol for gold?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Go", IsCorrect = false },
                new Answer { Text = "Gd", IsCorrect = false },
                new Answer { Text = "Au", IsCorrect = true },
                new Answer { Text = "Ag", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which of these is not a programming language?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Python", IsCorrect = false },
                new Answer { Text = "Java", IsCorrect = false },
                new Answer { Text = "HTML", IsCorrect = true },
                new Answer { Text = "C++", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "The theory of relativity was developed by:",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Isaac Newton", IsCorrect = false },
                new Answer { Text = "Albert Einstein", IsCorrect = true },
                new Answer { Text = "Galileo Galilei", IsCorrect = false },
                new Answer { Text = "Stephen Hawking", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which of these is not a type of rock?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Igneous", IsCorrect = false },
                new Answer { Text = "Sedimentary", IsCorrect = false },
                new Answer { Text = "Metamorphic", IsCorrect = false },
                new Answer { Text = "Liquid", IsCorrect = true }
            }
        },
        new Question
        {
            Text = "Who discovered penicillin?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Alexander Fleming", IsCorrect = true },
                new Answer { Text = "Louis Pasteur", IsCorrect = false },
                new Answer { Text = "Marie Curie", IsCorrect = false },
                new Answer { Text = "Robert Koch", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which planet has the most moons?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Jupiter", IsCorrect = false },
                new Answer { Text = "Saturn", IsCorrect = true },
                new Answer { Text = "Uranus", IsCorrect = false },
                new Answer { Text = "Neptune", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "The Great Pyramid of Giza was built for which pharaoh?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Tutankhamun", IsCorrect = false },
                new Answer { Text = "Ramses II", IsCorrect = false },
                new Answer { Text = "Khufu", IsCorrect = true },
                new Answer { Text = "Cleopatra", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which of these are types of electromagnetic radiation?",
            isMultipleChoice = true,
            Answers = new List<Answer>
            {
                new Answer { Text = "X-rays", IsCorrect = true },
                new Answer { Text = "Radio waves", IsCorrect = true },
                new Answer { Text = "Sound waves", IsCorrect = false },
                new Answer { Text = "Gamma rays", IsCorrect = true },
                new Answer { Text = "Ocean waves", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Who composed the 'Moonlight Sonata'?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Mozart", IsCorrect = false },
                new Answer { Text = "Beethoven", IsCorrect = true },
                new Answer { Text = "Bach", IsCorrect = false },
                new Answer { Text = "Chopin", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "What is the largest planet in our solar system?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Earth", IsCorrect = false },
                new Answer { Text = "Jupiter", IsCorrect = true },
                new Answer { Text = "Saturn", IsCorrect = false },
                new Answer { Text = "Neptune", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which of these is not a mammal?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Dolphin", IsCorrect = false },
                new Answer { Text = "Bat", IsCorrect = false },
                new Answer { Text = "Platypus", IsCorrect = false },
                new Answer { Text = "Penguin", IsCorrect = true }
            }
        },
        new Question
        {
            Text = "The Eiffel Tower is located in which city?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "London", IsCorrect = false },
                new Answer { Text = "Berlin", IsCorrect = false },
                new Answer { Text = "Paris", IsCorrect = true },
                new Answer { Text = "Rome", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which gas makes up the majority of Earth's atmosphere?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Oxygen", IsCorrect = false },
                new Answer { Text = "Carbon dioxide", IsCorrect = false },
                new Answer { Text = "Nitrogen", IsCorrect = true },
                new Answer { Text = "Hydrogen", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which of these is not a bone in the human body?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Femur", IsCorrect = false },
                new Answer { Text = "Tibia", IsCorrect = false },
                new Answer { Text = "Radius", IsCorrect = false },
                new Answer { Text = "Aorta", IsCorrect = true }
            }
        },
        new Question
        {
            Text = "Who was the first person to walk on the moon?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Neil Armstrong", IsCorrect = true },
                new Answer { Text = "Buzz Aldrin", IsCorrect = false },
                new Answer { Text = "Yuri Gagarin", IsCorrect = false },
                new Answer { Text = "John Glenn", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which of these is not a prime number?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "2", IsCorrect = false },
                new Answer { Text = "3", IsCorrect = false },
                new Answer { Text = "5", IsCorrect = false },
                new Answer { Text = "9", IsCorrect = true }
            }
        },
        new Question
        {
            Text = "The currency of Japan is:",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Won", IsCorrect = false },
                new Answer { Text = "Yuan", IsCorrect = false },
                new Answer { Text = "Yen", IsCorrect = true },
                new Answer { Text = "Ringgit", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which of these are Nobel prizes awarded in?",
            isMultipleChoice = true,
            Answers = new List<Answer>
            {
                new Answer { Text = "Physics", IsCorrect = true },
                new Answer { Text = "Chemistry", IsCorrect = true },
                new Answer { Text = "Medicine", IsCorrect = true },
                new Answer { Text = "Literature", IsCorrect = true },
                new Answer { Text = "Peace", IsCorrect = true },
                new Answer { Text = "Mathematics", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which country is home to the kangaroo?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "South Africa", IsCorrect = false },
                new Answer { Text = "Brazil", IsCorrect = false },
                new Answer { Text = "Australia", IsCorrect = true },
                new Answer { Text = "New Zealand", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "The chemical symbol for sodium is:",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "So", IsCorrect = false },
                new Answer { Text = "Na", IsCorrect = true },
                new Answer { Text = "No", IsCorrect = false },
                new Answer { Text = "Sd", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Who wrote '1984'?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Aldous Huxley", IsCorrect = false },
                new Answer { Text = "George Orwell", IsCorrect = true },
                new Answer { Text = "Ray Bradbury", IsCorrect = false },
                new Answer { Text = "H.G. Wells", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which of these is not a type of cloud?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Cumulus", IsCorrect = false },
                new Answer { Text = "Stratus", IsCorrect = false },
                new Answer { Text = "Cirrus", IsCorrect = false },
                new Answer { Text = "Solidus", IsCorrect = true }
            }
        },
        new Question
        {
            Text = "The capital of New Zealand is:",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Auckland", IsCorrect = false },
                new Answer { Text = "Christchurch", IsCorrect = false },
                new Answer { Text = "Wellington", IsCorrect = true },
                new Answer { Text = "Hamilton", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which of these is not a gas giant?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Jupiter", IsCorrect = false },
                new Answer { Text = "Saturn", IsCorrect = false },
                new Answer { Text = "Uranus", IsCorrect = false },
                new Answer { Text = "Mars", IsCorrect = true }
            }
        },
        new Question
        {
            Text = "The author of 'Pride and Prejudice' is:",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Charlotte Brontë", IsCorrect = false },
                new Answer { Text = "Jane Austen", IsCorrect = true },
                new Answer { Text = "Emily Brontë", IsCorrect = false },
                new Answer { Text = "Virginia Woolf", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which of these is not a type of triangle?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Equilateral", IsCorrect = false },
                new Answer { Text = "Isosceles", IsCorrect = false },
                new Answer { Text = "Scalene", IsCorrect = false },
                new Answer { Text = "Rectangular", IsCorrect = true }
            }
        },
        new Question
        {
            Text = "The largest desert in the world is:",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Sahara", IsCorrect = false },
                new Answer { Text = "Arabian", IsCorrect = false },
                new Answer { Text = "Gobi", IsCorrect = false },
                new Answer { Text = "Antarctic", IsCorrect = true }
            }
        },
        new Question
        {
            Text = "Which of these are types of renewable energy?",
            isMultipleChoice = true,
            Answers = new List<Answer>
            {
                new Answer { Text = "Solar", IsCorrect = true },
                new Answer { Text = "Wind", IsCorrect = true },
                new Answer { Text = "Coal", IsCorrect = false },
                new Answer { Text = "Natural gas", IsCorrect = false },
                new Answer { Text = "Hydroelectric", IsCorrect = true },
                new Answer { Text = "Nuclear", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "The inventor of the telephone was:",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Thomas Edison", IsCorrect = false },
                new Answer { Text = "Alexander Graham Bell", IsCorrect = true },
                new Answer { Text = "Nikola Tesla", IsCorrect = false },
                new Answer { Text = "Guglielmo Marconi", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which of these is not a zodiac sign?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Leo", IsCorrect = false },
                new Answer { Text = "Libra", IsCorrect = false },
                new Answer { Text = "Orion", IsCorrect = true },
                new Answer { Text = "Cancer", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "The longest river in Europe is:",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Danube", IsCorrect = false },
                new Answer { Text = "Rhine", IsCorrect = false },
                new Answer { Text = "Volga", IsCorrect = true },
                new Answer { Text = "Thames", IsCorrect = false }
            }
        },
        new Question
        {
            Text = "Which of these is not a type of volcano?",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Shield", IsCorrect = false },
                new Answer { Text = "Composite", IsCorrect = false },
                new Answer { Text = "Cinder cone", IsCorrect = false },
                new Answer { Text = "Flat", IsCorrect = true }
            }
        },
        new Question
        {
            Text = "The artist who painted 'The Starry Night' was:",
            isMultipleChoice = false,
            Answers = new List<Answer>
            {
                new Answer { Text = "Pablo Picasso", IsCorrect = false },
                new Answer { Text = "Vincent van Gogh", IsCorrect = true },
                new Answer { Text = "Claude Monet", IsCorrect = false },
                new Answer { Text = "Salvador Dalí", IsCorrect = false }
            }
        }
    }
    };

    public List<Result> results = new List<Result>
    {
        new Result { UserId = 1, QuizId = 1, Score = 20 },
        new Result { UserId = 1, QuizId = 2, Score = 20 },
        new Result { UserId = 1, QuizId = 3, Score = 20 },
        new Result { UserId = 1, QuizId = 4, Score = 20 },

        new Result { UserId = 2, QuizId = 1, Score = 17 },
        new Result { UserId = 2, QuizId = 2, Score = 15 },
        new Result { UserId = 2, QuizId = 3, Score = 19 },
        new Result { UserId = 2, QuizId = 4, Score = 13 },

        new Result { UserId = 3, QuizId = 1, Score = 11 },
        new Result { UserId = 3, QuizId = 2, Score = 18 },
        new Result { UserId = 3, QuizId = 3, Score = 14 },
        new Result { UserId = 3, QuizId = 4, Score = 18 },

        new Result { UserId = 4, QuizId = 1, Score = 16 },
        new Result { UserId = 4, QuizId = 2, Score = 12 },
        new Result { UserId = 4, QuizId = 3, Score = 15 },
        new Result { UserId = 4, QuizId = 4, Score = 19 },

        new Result { UserId = 5, QuizId = 1, Score = 13 },
        new Result { UserId = 5, QuizId = 2, Score = 17 },
        new Result { UserId = 5, QuizId = 3, Score = 17 },
        new Result { UserId = 5, QuizId = 4, Score = 14 },

        new Result { UserId = 6, QuizId = 1, Score = 18 },
        new Result { UserId = 6, QuizId = 2, Score = 14 },
        new Result { UserId = 6, QuizId = 3, Score = 16 },
        new Result { UserId = 6, QuizId = 4, Score = 12 },

        new Result { UserId = 7, QuizId = 1, Score = 15 },
        new Result { UserId = 7, QuizId = 2, Score = 19 },
        new Result { UserId = 7, QuizId = 3, Score = 13 },
        new Result { UserId = 7, QuizId = 4, Score = 17 },

        new Result { UserId = 8, QuizId = 1, Score = 17 },
        new Result { UserId = 8, QuizId = 2, Score = 16 },
        new Result { UserId = 8, QuizId = 3, Score = 18 },
        new Result { UserId = 8, QuizId = 4, Score = 14 },

        new Result { UserId = 9, QuizId = 1, Score = 12 },
        new Result { UserId = 9, QuizId = 2, Score = 15 },
        new Result { UserId = 9, QuizId = 3, Score = 17 },
        new Result { UserId = 9, QuizId = 4, Score = 19 },

        new Result { UserId = 10, QuizId = 1, Score = 14 },
        new Result { UserId = 10, QuizId = 2, Score = 18 },
        new Result { UserId = 10, QuizId = 3, Score = 12 },
        new Result { UserId = 10, QuizId = 4, Score = 16 },

        new Result { UserId = 11, QuizId = 1, Score = 17 },
        new Result { UserId = 11, QuizId = 2, Score = 13 },
        new Result { UserId = 11, QuizId = 3, Score = 15 },
        new Result { UserId = 11, QuizId = 4, Score = 20 },

        new Result { UserId = 12, QuizId = 1, Score = 16 },
        new Result { UserId = 12, QuizId = 2, Score = 12 },
        new Result { UserId = 12, QuizId = 3, Score = 19 },
        new Result { UserId = 12, QuizId = 4, Score = 14 },

        new Result { UserId = 13, QuizId = 1, Score = 15 },
        new Result { UserId = 13, QuizId = 2, Score = 17 },
        new Result { UserId = 13, QuizId = 3, Score = 13 },
        new Result { UserId = 13, QuizId = 4, Score = 18 },

        new Result { UserId = 14, QuizId = 1, Score = 19 },
        new Result { UserId = 14, QuizId = 2, Score = 14 },
        new Result { UserId = 14, QuizId = 3, Score = 16 },
        new Result { UserId = 14, QuizId = 4, Score = 12 },

        new Result { UserId = 15, QuizId = 1, Score = 18 },
        new Result { UserId = 15, QuizId = 2, Score = 15 },
        new Result { UserId = 15, QuizId = 3, Score = 17 },
        new Result { UserId = 15, QuizId = 4, Score = 13 }
    };

    public List<User> users = new List<User>
    {
        new User { Username = "hu55ux",     Password = PasswordHelper.HashPassword("ab1!cd2e"), Birthdate = new DateTime(2000, 5, 21) },
        new User { Username = "abbass11",   Password = PasswordHelper.HashPassword("xy9@lm3n"), Birthdate = new DateTime(1998, 11, 3) },
        new User { Username = "murad_dev",  Password = PasswordHelper.HashPassword("qw1#er2t"), Birthdate = new DateTime(1995, 2, 14) },
        new User { Username = "ako_isi",    Password = PasswordHelper.HashPassword("mn4$op5q"), Birthdate = new DateTime(1988, 7, 19) },
        new User { Username = "gulcinSeki", Password = PasswordHelper.HashPassword("az7*ty8u"), Birthdate = new DateTime(1999, 12, 1) },
        new User { Username = "hajili",     Password = PasswordHelper.HashPassword("bc1!de2f"), Birthdate = new DateTime(2002, 6, 15) },
        new User { Username = "ayla",       Password = PasswordHelper.HashPassword("kl2@mn3o"), Birthdate = new DateTime(2001, 8, 25) },
        new User { Username = "emil",       Password = PasswordHelper.HashPassword("st4#uv5w"), Birthdate = new DateTime(1977, 4, 9) },
        new User { Username = "leyla",      Password = PasswordHelper.HashPassword("gh6$ij7k"), Birthdate = new DateTime(1996, 1, 30) },
        new User { Username = "orxan",      Password = PasswordHelper.HashPassword("rs8%tu9v"), Birthdate = new DateTime(1995, 9, 13) },
        new User { Username = "sevinj",     Password = PasswordHelper.HashPassword("de1!fg2h"), Birthdate = new DateTime(2000, 3, 5) },
        new User { Username = "rashad",     Password = PasswordHelper.HashPassword("wx3@yz4a"), Birthdate = new DateTime(1988, 10, 17) },
        new User { Username = "kamran",     Password = PasswordHelper.HashPassword("lm5#no6p"), Birthdate = new DateTime(1992, 12, 23) },
        new User { Username = "gunay",      Password = PasswordHelper.HashPassword("qr7$st8u"), Birthdate = new DateTime(1998, 6, 7) },
        new User { Username = "tural",      Password = PasswordHelper.HashPassword("op9*qr1s"), Birthdate = new DateTime(1994, 4, 11) }

    };

}
