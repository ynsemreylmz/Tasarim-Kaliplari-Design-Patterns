
Camera camera1 = Camera.GetCamera("NIKON");
Camera camera2 = Camera.GetCamera("CANON");
Camera camera3 = Camera.GetCamera("NIKON");
Camera camera4 = Camera.GetCamera("CANON");
Camera camera5 = Camera.GetCamera("SONNY");

Console.WriteLine(camera1.Id);
Console.WriteLine(camera2.Id);
Console.WriteLine(camera3.Id);
Console.WriteLine(camera4.Id);
Console.WriteLine(camera5.Id);
class Camera
{
	static Dictionary<string, Camera> _cameras = new Dictionary<string, Camera>();
	static object _lock = new object();
	private string _brand;
    public Guid Id { get; set; }
    private Camera()
	{
		Id = Guid.NewGuid();
	}

	public static Camera GetCamera(string brand)
	{
		lock (_lock)
		{
			if (!_cameras.ContainsKey(brand))
			{
				_cameras.Add(brand, new Camera());
			}
		}
		return _cameras[brand];
	}
}
