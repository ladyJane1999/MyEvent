using MyEvent;

var m = new MyArray<int>();

m.eventHandler += SampleEventHandler;

m.Add(1);
m.Remove(0);

static void SampleEventHandler(object sender,string s)
{
    Console.WriteLine("SampleEvent Handler: Calling Method");
}
    
