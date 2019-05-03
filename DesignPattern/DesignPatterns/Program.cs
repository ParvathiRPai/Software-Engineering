using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public interface IStateMachine<T>
    {
        T CurrentState { get; set; }
        void Start();
    }

    public interface IBedtimeState
    {
        void Handle(IStateMachine<IBedtimeState> stateMachine);
    }

    public class BedtimeStateMachine : IStateMachine<IBedtimeState>
    {
        public IBedtimeState CurrentState { get; set; }

        public BedtimeStateMachine()
        {
            CurrentState = new BedTime();
        }

        public void Start()
        {
            if (CurrentState == null)
                CurrentState = new BedTime();

            while (CurrentState != null)
                CurrentState.Handle(this);
        }
    }

    public class BedTime : IBedtimeState
    {
        public void Handle(IStateMachine<IBedtimeState> stateMachine)
        {
            Console.WriteLine("Nap time!");
            stateMachine.CurrentState = new TakingAShower();
        }
    }

    public class TakingAShower : IBedtimeState
    {
        public void Handle(IStateMachine<IBedtimeState> stateMachine)
        {
            Console.WriteLine("Shower time!");
            stateMachine.CurrentState = new BrushingTeeth();
        }
    }

    public class BrushingTeeth : IBedtimeState
    {
        public void Handle(IStateMachine<IBedtimeState> stateMachine)
        {
            Console.WriteLine("Brushing teeth");
            stateMachine.CurrentState = new GoingToSleep();
        }
    }

    public class GoingToSleep : IBedtimeState
    {
        public void Handle(IStateMachine<IBedtimeState> stateMachine)
        {
            Console.WriteLine("Going to sleeeeeeep...");
            stateMachine.CurrentState = null;
        }
    }


    public class ValueChangedEventArgs
    {
        public int OldValue { get; set; }
        public int NewValue { get; set; }
    }

    public interface IValueObserver
    {
        int Value { get; set; }
        void Subscribe(ISubscriber sub);
        void Unsubscribe(ISubscriber sub);
    }
    public interface ISubscriber
    {
        void Update(object sender, ValueChangedEventArgs args);
    }
    public class Subscriber : ISubscriber
    {
        public void Update(object sender, ValueChangedEventArgs args)
        {
            Console.WriteLine($"Old Value: {args.OldValue}, New Value: {args.NewValue}");
        }
    }
    public class ValueObserver : IValueObserver
    {
        private event EventHandler<ValueChangedEventArgs> valueChanged;

        private int myValue;
        public int Value
        {
            get
            {
                return myValue;
            }
            set
            {
                var oldValue = myValue;
                var newValue = value;
                myValue = value;

                var args = new ValueChangedEventArgs();
                args.OldValue = oldValue;
                args.NewValue = newValue;

                if (valueChanged != null)
                    valueChanged(this, args);
            }
        }

        public void Subscribe(ISubscriber sub)
        {
            valueChanged += sub.Update;
        }

        public void Unsubscribe(ISubscriber sub)
        {
            valueChanged -= sub.Update;
        }
    }


    public interface INumberCommand
    {
        int CurrentValue { get; }
        void Execute();
        void Undo();
    }

    public interface INumberCommandManager
    {
        void Execute(INumberCommand command);
        void Undo();
        void Redo();
    }

    public class AddCommand : INumberCommand
    {
        public int CurrentValue { get; protected set; }
        public int NumberToAdd { get; protected set; }

        public AddCommand(int currentValue, int numberToAdd)
        {
            CurrentValue = currentValue;
            NumberToAdd = numberToAdd;
        }
        public void Execute()
        {
            CurrentValue += NumberToAdd;
        }

        public void Undo()
        {
            CurrentValue -= NumberToAdd;
        }
    }

    public class CommandManager : INumberCommandManager
    {
        private Stack<INumberCommand> commands;
        public int CurrentValue
        {
            get
            {
                if (commands.Count == 0)
                    return 0;

                return commands.Peek().CurrentValue;
            }
        }

        public CommandManager()
        {
            commands = new Stack<INumberCommand>();
        }

        public void Execute(INumberCommand command)
        {
            command.Execute();
            commands.Push(command);
        }

        public void Redo()
        {
            if (commands.Count == 0)
                return;

            var lastCommand = commands.Peek();
            lastCommand.Execute();
            commands.Push(lastCommand);
        }

        public void Undo()
        {
            if (commands.Count == 0)
                return;

            var lastCommand = commands.Pop();
            lastCommand.Undo();
        }
    }


    public interface TheirInterface
    {
        List<int> GetNums();
    }
    public interface MyInterface
    {
        IEnumerable<int> GetNums();
    }
    public class MyClass : MyInterface
    {
        public IEnumerable<int> GetNums()
        {
            throw new NotImplementedException();
        }
    }

    // using class adapter
    public class MyClassAdapter : MyClass, TheirInterface
    {
        List<int> TheirInterface.GetNums()
        {
            return GetNums().ToList();
        }
    }

    // using object adapter
    public class MyClassAdapter2 : TheirInterface
    {
        private MyClass mc;

        public MyClassAdapter2(MyClass mc)
        {
            this.mc = mc;
        }

        public List<int> GetNums()
        {
            return mc.GetNums().ToList();
        }
    }


    public class SingletonHelloWorld
    {
        private static SingletonHelloWorld instance;

        private SingletonHelloWorld() { }

        public static SingletonHelloWorld GetInstance()
        {
            if (instance == null)
                instance = new SingletonHelloWorld();

            return instance;
        }
    }

    public class Dependency1
    {
        public void DoSomething()
        {
            Console.WriteLine("Did something");
        }
    }

    public class Dependency2
    {
        public void DoSomethingElse()
        {
            Console.WriteLine("Did something else");
        }
    }

    public class Consumer2
    {
        public void DoSomething(Dependency1 d)
        {
            //var d = new Dependency1();
            d.DoSomething();
        }

        public void DoSomethingElse(Dependency2 d)
        {
            //var d = new Dependency2();
            d.DoSomethingElse();
        }
    }


    public class Dependency
    {
        public void DoSomething()
        {
            Console.WriteLine("Did something");
        }

        public void DoSomethingElse()
        {
            Console.WriteLine("Did something else");
        }
    }

    public class Consumer
    {
        private Dependency d;

        public Consumer(Dependency d)
        {
            this.d = d;
        }

        public void DoSomething()
        {
            //var d = new Dependency();
            d.DoSomething();
        }

        public void DoSomethingElse()
        {
            //var d = new Dependency();
            d.DoSomethingElse();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //var sub = new Subscriber();
            //var observer = new ValueObserver();

            //observer.Subscribe(sub);
            //observer.Value = 200;

            //observer.Unsubscribe(sub);
            //observer.Value = 100;

            var machine = new BedtimeStateMachine();
            machine.Start();

            Console.ReadLine();
        }
    }
}
