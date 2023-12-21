//using CoreBusiness;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using UseCases.DataStorePluginInterfaces;

//namespace Plugins.DataStore.InMemory
//{
//    public class ToDoTaskInMemoryRepository : IToDoTaskRepository
//    {
//        #region Private Fields

//        private List<ToDoTask> toDoTasks;

//        #endregion
//        // ---
//        #region Public Methods

//        public ToDoTaskInMemoryRepository()
//        {
//            toDoTasks = new List<ToDoTask>()
//            {
//                new() { ToDoTaskId = 1, IsAtWork = true, 
//                    Category = "Посылки",
//                    Description = "",
//                    Task = "Настроить обьединение посылок", Page = "/packages",
//                    SubTasks =  {
//                       new() {
//                           SubToDoTaskId = 1,
//                           Task = "Настроить выделение нескольких посылок.",
//                           IsCompleted = true
//                       },
//                       new() {
//                           SubToDoTaskId = 2,
//                           Task = "Настроить сохранение выделенных посылок в List."
//                       }
//                    }
//                },
//                new() { ToDoTaskId = 2,
//                    Category = "Посылки",
//                    Description = "",
//                    Task = "Настроить разделение посылок", Page = "/packages"
//                },
//                new() { ToDoTaskId = 3,
//                    Category = "Посылки",
//                    Description = "",
//                    Task = "Настроить Отправку посылок в РБ", Page = "/packages"
//                },

//                new() { ToDoTaskId = 4,
//                    Category = "Index",
//                    Description = "",
//                    Task = "Привязка объектов к пользователю", Page = ""
//                },
//                new() { ToDoTaskId = 5,
//                    Category = "Профиль",
//                    Description = "",
//                    Task = "Дизайн редактирования профиля", Page = ""
//                },
//                new() { ToDoTaskId = 6,
//                    Category = "Получатели",
//                    Description = "",
//                    Task = "Загрузка скана паспорта", Page = ""
//                },
//                new() { ToDoTaskId = 7,
//                    Category = "Товары",
//                    Description = "",
//                    Task = "Загрузка скрина инвойса", Page = ""
//                },
//                new() { ToDoTaskId = 8,
//                    Category = "Посылки",
//                    Description = "",
//                    Task = "Редактирование посылок администратором", Page = ""
//                },
//                new() { ToDoTaskId = 9,
//                    Category = "ExpressPay",
//                    Description = "",
//                    Task = "Добавить вкладку ExpressPay", Page = ""
//                },
//                new() { ToDoTaskId = 10,
//                    Category = "Белка",
//                    Description = "",
//                    Task = "Добавить вкладку Белка", Page = ""
//                },
//                new() { ToDoTaskId = 11, Description = "",
//                    Task = "Добавить вкладку Яндекс карты", Page = ""
//                },
//                new() { ToDoTaskId = 12, Description = "",
//                    Task = "Добавить поле скидка. Добавить столбец Скидка в таблицу Стоимости доставки", Page = ""
//                },
//                new() { ToDoTaskId = 13, Description = "",
//                    Task = "Модальные попапы в редактировании покупок заменить на ВВМодал", Page = ""
//                },
//                new() { ToDoTaskId = 14, Description = "",
//                    Task = "В компонентах Селект... Добавить выделение строк", Page = ""
//                },
//                new() { ToDoTaskId = 15, Description = "",
//                    Task = "Добавить систему логирования", Page = ""
//                },
//                new() { ToDoTaskId = 16, Description = "",
//                    Task = "Написать Тесты для репозиториев", Page = ""
//                },
//                new() { ToDoTaskId = 17, Description = "",
//                    Task = "Выгрузить получателей из белки и сохранить в Excel", Page = ""
//                },
//                new() { ToDoTaskId = 18,
//                    Category = "Посылки",
//                    Description = "",
//                    Task = "Исправить дизайн (DesctopView)", 
//                    Page = "",
//                    IsCompleted = true
//                },
//                //new() { ToDoTaskId = 19, Description = "",
//                //    Task = "Добавить диаграмму", Page = ""
//                //},
//                //new() { ToDoTaskId = 20, Description = "",
//                //    Task = "...", Page = ""},
                
//                // IsCompleted = true
//                new() { ToDoTaskId = 21, Description = "",
//                    Task = "Фильтрация посылок по статусу", Page = "/packages", IsCompleted = true
//                }
//            };
//        }

//        public IEnumerable<ToDoTask> GetToDoTasks()
//        {
//            return toDoTasks;
//        }

//        public ToDoTask? GetToDoTaskById(int toDoTaskId)
//        {
//            return toDoTasks?.FirstOrDefault(x => x.ToDoTaskId == toDoTaskId);
//        }

//        public IEnumerable<ToDoTask>? GetToDoTasksByCategory(string category)
//        {
//            return toDoTasks.Where(x => x.Category == category);
//        }

//        #endregion
//    }
//}
