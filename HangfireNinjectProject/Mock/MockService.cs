using System.Threading;
using System.Threading.Tasks;

namespace HangfireNinjectProject.Mock
{
	public class MockService : IMockService
	{

		public void DoSomethingDelayed(MockObject mockObject)
		{
			for (var i = 1; i <= 60; i++)
			{
				Thread.Sleep(100);
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
	}
}