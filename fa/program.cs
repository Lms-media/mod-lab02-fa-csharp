using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
  public class State
  {
    public string Name;
    public Dictionary<char, State> Transitions;
    public bool IsAcceptState;
  }

  public class FA1
  {
    public static State q0 = new State()
    {
      Name = "q0",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };
    public State q1 = new State()
    {
      Name = "q1",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };
    public State q2 = new State()
    {
      Name = "q2",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };
    public State qY = new State()
    {
      Name = "q+",
      IsAcceptState = true,
      Transitions = new Dictionary<char, State>()
    };
    public State qN = new State()
    {
      Name = "q-",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };

    State InitialState = q0;
    public FA1()
    {
      q0.Transitions['0'] = q1;
      q0.Transitions['1'] = q2;
      q1.Transitions['0'] = qN;
      q1.Transitions['1'] = qY;
      q2.Transitions['0'] = qY;
      q2.Transitions['1'] = q2;
      qY.Transitions['0'] = qN;
      qY.Transitions['1'] = qY;
      qN.Transitions['0'] = qN;
      qN.Transitions['1'] = qN;
    }
    public bool? Run(IEnumerable<char> s)
    {
      State current = InitialState;
      foreach (var c in s)
      {
        current = current.Transitions[c];
        if (current == null)
          return null;
      }
      return current.IsAcceptState;
    }
  }

  public class FA2
  {
    public static State q0 = new State()
    {
      Name = "q0",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };
    public State q1 = new State()
    {
      Name = "q1",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };
    public State q2 = new State()
    {
      Name = "q2",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };
    public State qY = new State()
    {
      Name = "q+",
      IsAcceptState = true,
      Transitions = new Dictionary<char, State>()
    };

    State InitialState = q0;
    public FA2()
    {
      q0.Transitions['0'] = q1;
      q0.Transitions['1'] = q2;
      q1.Transitions['0'] = q0;
      q1.Transitions['1'] = qY;
      q2.Transitions['0'] = qY;
      q2.Transitions['1'] = q0;
      qY.Transitions['0'] = q2;
      qY.Transitions['1'] = q1;
    }
    public bool? Run(IEnumerable<char> s)
    {
      State current = InitialState;
      foreach (var c in s)
      {
        current = current.Transitions[c];
        if (current == null)
          return null;
      }
      return current.IsAcceptState;
    }
  }

  public class FA3
  {
    public static State q0 = new State()
    {
      Name = "q0",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };
    public State q1 = new State()
    {
      Name = "q1",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };
    public State qY = new State()
    {
      Name = "q+",
      IsAcceptState = true,
      Transitions = new Dictionary<char, State>()
    };

    State InitialState = q0;
    public FA3()
    {
      q0.Transitions['0'] = q0;
      q0.Transitions['1'] = q1;
      q1.Transitions['0'] = q0;
      q1.Transitions['1'] = qY;
      qY.Transitions['0'] = qY;
      qY.Transitions['1'] = qY;
    }
    public bool? Run(IEnumerable<char> s)
    {
      State current = InitialState;
      foreach (var c in s)
      {
        current = current.Transitions[c];
        if (current == null)
          return null;
      }
      return current.IsAcceptState;
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      String s = "01111";
      FA1 fa1 = new FA1();
      bool? result1 = fa1.Run(s);
      Console.WriteLine(result1);
      FA2 fa2 = new FA2();
      bool? result2 = fa2.Run(s);
      Console.WriteLine(result2);
      FA3 fa3 = new FA3();
      bool? result3 = fa3.Run(s);
      Console.WriteLine(result3);
    }
  }
}
