//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Plugins.PMBoK;
//using UseCases.DataStorePluginInterfaces;
//using UseCases.UseCaseInterfaces;

//namespace UseCases.ToDoTasksUseCases
//{
//    public class GetToDoTaskUseCase : IGetToDoTaskUseCase
//    {
//        private readonly IToDoTaskRepository toDoTaskRepository;

//        public GetToDoTaskUseCase(IToDoTaskRepository toDoTaskRepository)
//        {
//            this.toDoTaskRepository = toDoTaskRepository;
//        }

//        public ToDoTask Execute(int toDoTaskId)
//            => toDoTaskRepository.GetToDoTaskById(toDoTaskId);
//    }
//}
