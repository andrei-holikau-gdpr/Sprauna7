//using Plugins.PMBoK;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using UseCases.DataStorePluginInterfaces;
//using UseCases.UseCaseInterfaces;

//namespace UseCases.ToDoTasksUseCases
//{
//    public class ViewToDoTasksUseCase : IViewToDoTasksUseCase
//    {
//        private readonly IToDoTaskRepository toDoTaskRepository;

//        public ViewToDoTasksUseCase(IToDoTaskRepository toDoTaskRepository)
//        {
//            this.toDoTaskRepository = toDoTaskRepository;
//        }

//        public IEnumerable<ToDoTask> Execute()
//            => toDoTaskRepository.GetToDoTasks();
//    }
//}
