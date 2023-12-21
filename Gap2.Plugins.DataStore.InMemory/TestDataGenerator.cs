using Gap2.CoreBusiness;

namespace Gap2.Plugins.DataStore.InMemory
{
    public class TestDataGenerator
    {
        public List<ImageHtmlTag>? Images;

        public List<Process>? Processes;
        public List<Jurisdiction>? Jurisdictions;
        public List<QuestionType>? QuestionTypes;
        public List<Question>? Questions;
        public List<Answer>? Answers;
        public List<StatusAppliacability>? StatusAppliacabilities;

        public StatusAppliacability statusAppliacability;

        public GapResult GapResults = new();

        public TestDataGenerator()
        {
            Images = GenerateImages();
            Processes = GenerateProcesses();
StatusAppliacabilities = GenerateStatusAppliacabilities();
            Jurisdictions = GenerateJurisdictions();

            QuestionTypes = GenerateQuestionTypes();

            Answers = GenerateAnswers();
            Questions = GenerateQuestions();

            
        }

        public List<ImageHtmlTag> GenerateImages()
        {
            Images = new List<ImageHtmlTag>
            {
                new() { Id = 0, FileName = "processMail.png" },
                new() { Id = 1, FileName = "processMobile.jpg" },
                new() { Id = 2, FileName = "processRekrut.png" }
            };
            return Images;
        }
        public List<StatusAppliacability> GenerateStatusAppliacabilities()
        {
            StatusAppliacabilities = new List<StatusAppliacability>
            {
                new() { Id = 0, Name = "Applicable", Position = 0 },
                new() { Id = 1, Name = "NoApplicable", Position = 1 },
                new() { Id = 2, Name = "NotProcessed", Position = 2 }
            };
            return StatusAppliacabilities;
        }

        public List<Answer> GenerateAnswers()
        {
            Answers = new List<Answer>
            {
                new Answer { Id = 1, NotionId = "QA-",
                    Name = "The corporate body of the data controller is located in Mexico ",
                    YesDigitalEquivalent = 1,
                    NoDigitalEquivalent = 0,
                    QuestionId = 1, Position = 1 },
                new Answer { Id = 2,  NotionId = "QA-",
                    Name = "(In case of corporate bodies residing abroad), the principal management of the business of controller is in Mexico  ",
                    YesDigitalEquivalent = 1,
                    NoDigitalEquivalent = 0,
                    QuestionId = 1, Position = 2 },
                new Answer { Id = 3,  NotionId = "QA-",
                    Name = "The address that principal management of data controller designated as establishment is in Mexico ",
                    YesDigitalEquivalent = 1,
                    NoDigitalEquivalent = 0,
                    QuestionId = 1, Position = 3 },

                new Answer { Id = 4, NotionId = "QA-",
                    Name = "Controller",
                    YesDigitalEquivalent = 1,
                    NoDigitalEquivalent = 0,
                    QuestionId = 2 },
                new Answer { Id = 5, NotionId = "QA-",
                    Name = "Processor",
                   YesDigitalEquivalent = 1,
                    NoDigitalEquivalent = 0,
                    QuestionId = 2 },
                new Answer { Id = 6, NotionId = "QA-",
                    Name = "Proportional",
                    YesDigitalEquivalent = 1,
                    NoDigitalEquivalent = 0,
                    QuestionId = 3 },
                new Answer { Id = 7, NotionId = "QA-",
                    Name = "Disproportional",
                    YesDigitalEquivalent = 1,
                    NoDigitalEquivalent = 0,
                    QuestionId = 3 }
            };
            return Answers;
        }
        public List<Question> GenerateQuestions()
        {
            Questions = new List<Question>
            {
                new Question { 
                    Id = 0, 
                    NotionId = "QA-7", 
                    Name = "What is the situation for your processing?", 
                    Position = 1,
                    Answers = Answers.Where(x => x.QuestionId == 0).ToList(),

                    QuestionType = QuestionTypes[0],
                    QuestionTypeId = 1
                },
                new Question { 
                    Id = 1, 
                    NotionId = "QA-6", 
                    Name = "What is the role of your company", 
                    Position = 2,
                    Answers = Answers.Where(x => x.QuestionId == 2).ToList(),

                    QuestionType = QuestionTypes[0],
                    QuestionTypeId = 1
                },
                new Question { 
                    Id = 2, 
                    NotionId = "QA-5", 
                    Name = "How much effort or time do you need to access the personal data?", 
                    Position = 3,
                    Answers = Answers.Where(x => x.QuestionId == 3).ToList(),

                    QuestionType = QuestionTypes[1],
                    QuestionTypeId = 2
                },
                new Question { 
                    Id = 3, 
                    NotionId = "QA-4", 
                    Name = "Please select circumstances of this processing", 
                    Position = 4,
                    Answers = Answers.Where(x => x.QuestionId == 4).ToList(),

                    QuestionType = QuestionTypes[1],
                    QuestionTypeId = 2
                }
            };
            return Questions;
        }
        public List<QuestionType> GenerateQuestionTypes()
        {
            QuestionTypes = new List<QuestionType>
            {
                new QuestionType { 
                    Id = 0, 
                    Name = "MultiSelect", 
                    Position = 1 
                },
                new QuestionType { 
                    Id = 1, 
                    Name = "SingleSelect", 
                    Position = 2 
                },
                new QuestionType { 
                    Id = 2, 
                    Name = "Type 1", 
                    Position = 3 
                },
                new QuestionType { 
                    Id = 3, 
                    Name = "Type 2", 
                    Position = 4 
                }
            };
            return QuestionTypes;
        }
        public List<Jurisdiction> GenerateJurisdictions()
        {
            Jurisdictions = new List<Jurisdiction>
            {
                new() { 
                    Id = 1, 
                    Name = "Mexico", 
                    Position = 1,
                    StatusAppliacability = StatusAppliacabilities[2]
                },
                new() { 
                    Id = 2, 
                    Name = "Brazil", 
                    Position = 2,
                    StatusAppliacability = StatusAppliacabilities[2] 
                },
                new() { 
                    Id = 3, 
                    Name = "USA - California", 
                    Position = 4,
                    StatusAppliacability = StatusAppliacabilities[2] 
                },
                new() { 
                    Id = 4, 
                    Name = "India", 
                    Position = 5,
                    StatusAppliacability = StatusAppliacabilities[2] 
                }
            };
            return Jurisdictions;
        }
        public List<Process> GenerateProcesses()
        {
            if (Images == null)
            {
                Processes = new List<Process>();
            }
            else 
            { 
                Processes = new List<Process>
                {
                    new() {
                        Id = 0,
                        Name = "Мобильное приложение (В2С)",
                        Position = 0,
                        Image = Images[0]
                    },
                    new() {
                        Id = 1,
                        Name = "Маркетинговая рассылка",
                        Position = 1,
                        Image = Images[1]
                    },
                    new() {
                        Id = 2,
                        Name = "Рекрутинг",
                        Position = 2,
                        Image = Images[2]
                    }
                };
            } 
            return Processes;
        } 
    }
}