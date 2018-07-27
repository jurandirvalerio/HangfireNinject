using System;
using System.Threading.Tasks;

namespace HangfireNinjectProject.Mock
{
	public class MockService : IMockService
	{

		public void DoSomethingDelayed(MockObject mockObject)
		{
			for (var i = 1; i <= 20; i++)
			{
				Console.WriteLine(Fibonacci(i));
			}
		}

		public void DoSomethingBigger(MockObject mockObject)
		{
			Parallel.For(0, 60,
				index =>
				{
					mockObject.FakeNumber = index;
					DoSomethingDelayed(mockObject);
				});
		}

		private static int Fibonacci(int n)
		{
			var a = 0;
			var b = 1;
			for (var i = 0; i < n; i++)
			{
				var temp = a;
				a = b;
				b = temp + b;
			}
			return a;
		}
	}
}