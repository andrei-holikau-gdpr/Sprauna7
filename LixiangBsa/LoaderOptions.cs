using Lixiang.CoreBusiness;

namespace LixiangBsa
{
    public class LoaderOptions
    {
        public List<CarModel> CarModels { get; set; } = new();
        public List<CarColorOption> CarFasadColorOptions { get; set; } = new();
        public List<CarColorOption> CarInteriorColorOptions { get; set; } = new();
        public List<CarColorOption> CarWheelDisksOptions { get; set; } = new();
        public List<SimpleOption> OptionalEquipments { get; set; } = new();
        public List<ImageHtmlTag> ImageHtmlTags { get; set; } = new();

        public LoaderOptions()
        {
            LoadImageHtmlTags();
            LoadCarModels();
            LoadCarFasads();
            LoadCarInteriors();
            LoadCarWheelDisks();
            LoadOptionalEquipments();
        }

        private void LoadImageHtmlTags()
        {
            ImageHtmlTags.AddRange(new List<ImageHtmlTag>() {
                new ( 0, "lixiangL9.color.1.png", "Thumbnail" ),
                new ( 1, "lixiangL9.1.1.png" ),
                new ( 2, "lixiangL9.1.2.png" ),
                new ( 3, "lixiangL9.1.3.png" ),
                new ( 4, "lixiangL9.1.4.png" ),

                new ( 5, "lixiangL9.color.2.png", "Thumbnail" ),
                new ( 6, "lixiangL9.2.1.png" ),
                new ( 7, "lixiangL9.2.2.png" ),
                new ( 8, "lixiangL9.2.3.png" ),
                new ( 9, "lixiangL9.2.4.png" ),

                new ( 10, "lixiangL9.color.3.png", "Thumbnail" ),
                new ( 11, "lixiangL9.3.1.png" ),
                new ( 12, "lixiangL9.3.2.png" ),
                new ( 13, "lixiangL9.3.3.png" ),
                new ( 14, "lixiangL9.3.4.png" ),

                new ( 15, "lixiangL9.color.6.png", "Thumbnail" ),
                new ( 16, "lixiangL9.4.1.png" ),
                new ( 17, "lixiangL9.4.2.png" ),
                new ( 18, "lixiangL9.4.3.png" ),
                new ( 19, "lixiangL9.4.4.png" ),

                new ( 20, "lixiangL9.interior.1.png", "Thumbnail" ),
                new ( 21, "lixiangL9.2.1.1.png" ),
                new ( 22, "lixiangL9.2.1.1.png" ),
                new ( 23, "lixiangL9.2.1.1.png" ),
                new ( 24, "lixiangL9.2.1.1.png" ),

                new ( 25, "lixiangL9.interior.2.png", "Thumbnail" ),
                new ( 26, "lixiangL9.2.2.1.png" ),
                new ( 27, "lixiangL9.2.2.1.png" ),
                new ( 28, "lixiangL9.2.2.1.png" ),
                new ( 29, "lixiangL9.2.2.1.png" ),

                new ( 30, "lixiangL9.interior.3.png", "Thumbnail" ),
                new ( 31, "lixiangL9.2.3.1.png" ),
                new ( 32, "lixiangL9.2.3.1.png" ),
                new ( 33, "lixiangL9.2.3.1.png" ),
                new ( 34, "lixiangL9.2.3.1.png" ),

                new ( 35, "lixiangL9.hub.1.png", "Thumbnail" ),
                new ( 36, "lixiangL9.hubLarge.1.6.1.png" ),
                new ( 37, "lixiangL9.hubLarge.1.6.1.png" ),
                new ( 38, "lixiangL9.hubLarge.1.6.1.png" ),
                new ( 39, "lixiangL9.hubLarge.1.6.1.png" ),

                new ( 40, "lixiangL9.hub.2.png", "Thumbnail" ),
                new ( 41, "lixiangL9.hubLarge.1.6.2.png" ),
                new ( 42, "lixiangL9.hubLarge.1.6.2.png" ),
                new ( 43, "lixiangL9.hubLarge.1.6.2.png" ),
                new ( 44, "lixiangL9.hubLarge.1.6.2.png" ),

                new ( 45, "wancheng.gif", "Thumbnail" ),

                new ( 46, "lixiangL9.color.6.png", "Thumbnail" ),
                new ( 47, "lixiangL9.4.1.png" ),
                new ( 48, "lixiangL9.4.2.png" ),
                new ( 49, "lixiangL9.4.3.png" ),
                new ( 50, "lixiangL9.4.4.png" ),

                new ( 51, "lixiangL9.color.6.png", "Thumbnail" ),
                new ( 52, "lixiangL9.4.1.png" ),
                new ( 53, "lixiangL9.4.2.png" ),
                new ( 54, "lixiangL9.4.3.png" ),
                new ( 55, "lixiangL9.4.4.png" ),

                new ( 56, "lixiangL9.color.6.png", "Thumbnail" ),
                new ( 57, "lixiangL9.4.1.png" ),
                new ( 58, "lixiangL9.4.2.png" ),
                new ( 59, "lixiangL9.4.3.png" ),
                new ( 60, "lixiangL9.4.4.png" ),

                new ( 61, "lixiangL9.color.6.png", "Thumbnail" ),
                new ( 62, "lixiangL9.4.1.png" ),
                new ( 63, "lixiangL9.4.2.png" ),
                new ( 64, "lixiangL9.4.3.png" ),
                new ( 65, "lixiangL9.4.4.png" ),

                new ( 66, "lixiangL9.color.6.png", "Thumbnail" ),
                new ( 67, "lixiangL9.4.1.png" ),
                new ( 68, "lixiangL9.4.2.png" ),
                new ( 69, "lixiangL9.4.3.png" ),
                new ( 70, "lixiangL9.4.4.png" )
            }); 
        }

        private List<CarModel> LoadCarModels()
        {
            CarModels.AddRange(new List<CarModel> {
                new CarModel(){
                    Id = 1,
                    Name = "L8 Air",
                    Description = "Описание L8 Air",
                    Price = 339800,
                },
                new CarModel(){
                    Id = 2,
                    Name = "L8 Pro",
                    Description = "Описание L8 Pro",
                    Price = 359800,
                },
                new CarModel(){
                    Id = 3,
                    Name = "L8 Max",
                    Description = "Описание L8 Max",
                    Price = 399800,
                }
             });
            return CarModels;
        }
        private List<CarColorOption> LoadCarFasads()
        {
            CarFasadColorOptions = new List<CarColorOption> {
                new CarColorOption(){
                    Id = 1,
                    Name = "Окраска золотой металлик",
                    Description = "",
                    Price = 1,
                    Thumbnail = ImageHtmlTags[0],

                    Images = {
                        ImageHtmlTags[1],
                        ImageHtmlTags[2],
                        ImageHtmlTags[3],
                        ImageHtmlTags[4]
                    }
                },
                new CarColorOption(){
                    Id = 2,
                    Name = "Окраска серебристый металлик",
                    Description = "",
                    Price = 20000,
                    Thumbnail = ImageHtmlTags[5],

                    Images = {
                        ImageHtmlTags[6],
                        ImageHtmlTags[7],
                        ImageHtmlTags[8],
                        ImageHtmlTags[9]
                    }
                },
                new CarColorOption(){
                    Id = 3,
                    Name = "Окраска серый металлик",
                    Description = "",
                    Price = 30000,
                    Thumbnail = ImageHtmlTags[10],

                    Images = {
                        ImageHtmlTags[11],
                        ImageHtmlTags[12],
                        ImageHtmlTags[13],
                        ImageHtmlTags[14]
                    }
                },
                new CarColorOption(){
                    Id = 4,
                    Name = "Фиолетовый металлик",
                    Description = "",
                    Price = 40000,
                    Thumbnail = ImageHtmlTags[15],

                    Images = {
                        ImageHtmlTags[16],
                        ImageHtmlTags[17],
                        ImageHtmlTags[18],
                        ImageHtmlTags[19]
                    }
                },
                new CarColorOption(){
                    Id = 5,
                    Name = "Фиолетовый металлик",
                    Description = "",
                    Price = 40000,
                    Thumbnail = ImageHtmlTags[46],

                    Images = {
                        ImageHtmlTags[47],
                        ImageHtmlTags[48],
                        ImageHtmlTags[49],
                        ImageHtmlTags[50]
                    }
                },
                new CarColorOption(){
                    Id = 6,
                    Name = "Фиолетовый металлик",
                    Description = "",
                    Price = 40000,
                    Thumbnail = ImageHtmlTags[51],

                    Images = {
                        ImageHtmlTags[52],
                        ImageHtmlTags[53],
                        ImageHtmlTags[54],
                        ImageHtmlTags[55]
                    }
                },
                new CarColorOption(){
                    Id = 7,
                    Name = "Фиолетовый металлик",
                    Description = "",
                    Price = 40000,
                    Thumbnail = ImageHtmlTags[56],

                    Images = {
                        ImageHtmlTags[57],
                        ImageHtmlTags[58],
                        ImageHtmlTags[59],
                        ImageHtmlTags[60]
                    }
                }
            };
            return CarFasadColorOptions;
        }
        private List<CarColorOption> LoadCarInteriors()
        {
            CarInteriorColorOptions.AddRange(new List<CarColorOption> {
                new CarColorOption(){
                    Id = 1,
                    Name = "Черный и белый",
                    Description = "Снежный белый интерьер выполнен из экологически чистых материалов, безопасен для детей и имеет антиалергенный состав. Комбинирован кожей тончайшей выделки Nappa ",
                    Price = 1,
                    Thumbnail = ImageHtmlTags[20],

                    Images = {
                        ImageHtmlTags[21],
                        ImageHtmlTags[22],
                        ImageHtmlTags[23],
                        ImageHtmlTags[24]
                    }
                },
                new CarColorOption(){
                    Id = 2,
                    Name = "Черный и оранжевый",
                    Description = "",
                    Price = 2000,
                    Thumbnail = ImageHtmlTags[25],

                    Images = {
                        ImageHtmlTags[26],
                        ImageHtmlTags[27],
                        ImageHtmlTags[28],
                        ImageHtmlTags[29]
                    }
                },
                new CarColorOption(){
                    Id = 3,
                    Name = "Черный и кофейный ",
                    Description = "",
                    Price = 3000,
                    Thumbnail = ImageHtmlTags[30],

                    Images = {
                        ImageHtmlTags[31],
                        ImageHtmlTags[32],
                        ImageHtmlTags[33],
                        ImageHtmlTags[34]
                    }
                }
            });
            return CarInteriorColorOptions;
        }
        private List<CarColorOption> LoadCarWheelDisks()
        {
            CarWheelDisksOptions.AddRange(new List<CarColorOption> {
                new CarColorOption(){
                    Id = 1,
                    Name = "21-дюймовые двухцветные серебристо-серые диски",
                    Description = "Эти колесные диски с алмазной проточкой станут изысканным акцентом в образе вашего автомобиля. Выберите для них персональный цвет и получите еще более восхитительный эффект. Диски доступны в размере от 21 диаметра.",
                    Price = 100,
                    Thumbnail = ImageHtmlTags[35],

                    Images = {
                        ImageHtmlTags[36],
                        ImageHtmlTags[37],
                        ImageHtmlTags[38],
                        ImageHtmlTags[39]
                    }
                },
                new CarColorOption(){
                    Id = 2,
                    Name = "21-дюймовые двухцветные черно-серые диски ",
                    Description = "Эти колесные диски с алмазной проточкой станут изысканным акцентом в образе вашего автомобиля. Выберите для них персональный цвет и получите еще более восхитительный эффект. Диски доступны в размере от 21 диаметра. ",
                    Price = 200,
                    Thumbnail = ImageHtmlTags[40],

                    Images = {
                        ImageHtmlTags[41],
                        ImageHtmlTags[42],
                        ImageHtmlTags[43],
                        ImageHtmlTags[44]
                    }
                },
                new CarColorOption(){
                    Id = 3,
                    Name = "21-дюймовые двухцветные черно-серые диски ",
                    Description = "Эти колесные диски с алмазной проточкой станут изысканным акцентом в образе вашего автомобиля. Выберите для них персональный цвет и получите еще более восхитительный эффект. Диски доступны в размере от 21 диаметра. ",
                    Price = 200,
                    Thumbnail = ImageHtmlTags[61],

                    Images = {
                        ImageHtmlTags[62],
                        ImageHtmlTags[63],
                        ImageHtmlTags[64],
                        ImageHtmlTags[65]
                    }
                },
                new CarColorOption(){
                    Id = 4,
                    Name = "21-дюймовые двухцветные черно-серые диски ",
                    Description = "Эти колесные диски с алмазной проточкой станут изысканным акцентом в образе вашего автомобиля. Выберите для них персональный цвет и получите еще более восхитительный эффект. Диски доступны в размере от 21 диаметра. ",
                    Price = 200,
                    Thumbnail = ImageHtmlTags[66],

                    Images = {
                        ImageHtmlTags[67],
                        ImageHtmlTags[68],
                        ImageHtmlTags[69],
                        ImageHtmlTags[70]
                    }
                }
            });
            return CarWheelDisksOptions;
        }
        private List<SimpleOption> LoadOptionalEquipments()
        {
            OptionalEquipments.AddRange(new List<SimpleOption> {
                new SimpleOption()
                {
                    Id = 1,
                    Name = "Электро-выдвижные пороги",
                    Price = 10,
                    Description = "Выдвижные пороги, оборудованные электроприводом,\r\n                        - чрезвычайно полезный и удобный аксессуар,\r\n                        используемый для внедорожников и кроссоверов.\r\n                        Установка электропорогов актуальна для автомобилей премиум класса. Такие конструкции делают\r\n                        пользование автомобилем более комфортным.",
                    Thumbnail = ImageHtmlTags[45],
                }
            }
        );

            return OptionalEquipments;
        }
    }
}
