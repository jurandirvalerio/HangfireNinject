namespace HangfireNinjectProject.Mock
{
	public interface IMockService
	{
		void DoSomethingDelayed(MockObject mockObject);

		void DoSomethingBigger(MockObject mockObject);
	}
}