using System;
using System.Linq;
using System.Collections.Generic;


public interface IVehicle
{
    int Doors { get; set; }
    int PassengerCapacity { get; set; }
    string TransmissionType { get; set; }
    double EngineVolume { get; set; }

    void Start();
    void Stop();


}

public interface IWaterVehicle
{
  void Drive();
  double MaxWaterSpeed { get; set; }
}

public interface IAirVehicle
{
  void Fly();

  bool Winged { get; set; }

  double MaxAirSpeed { get; set; }

  int Wheels { get; set; }
}

public interface ILandVehicle
{
  void Drive();
  double MaxLandSpeed { get; set; }
}

public class JetSki : IVehicle, IWaterVehicle
{
    public int Doors { get; set; } = 0;
    public int PassengerCapacity { get; set; } = 2;
    public string TransmissionType { get; set; } = "Auto";
    public double EngineVolume { get; set; } = 3.5;
    public double MaxWaterSpeed { get; set; } = 400.1;

    public void Drive()
    {
        this.Start();
        Console.WriteLine("The jetski zips through the waves with the greatest of ease");
    }

    public void Start()
    {
        Console.WriteLine("The JetSki has been started time to break some shit!");
    }

    public void Stop()
    {
        Console.WriteLine("Sad day, you turned off the jet ski");
    }
}

public class Motorcycle : IVehicle, ILandVehicle
{
    public int Wheels { get; set; } = 2;
    public int Doors { get; set; } = 0;
    public int PassengerCapacity { get; set; } = 2;
    public string TransmissionType { get; set; } = "Manual";
    public double EngineVolume { get; set; } = 1.3;
    public double MaxLandSpeed { get; set; } = 160.4;

    public void Drive()
    {
        this.Start();
        Console.WriteLine("The motorcycle screams down the highway");
    }

    public void Start()
    {
        Console.WriteLine("*Obligatory motorcycle revving*");
    }

    public void Stop()
    {
        Console.WriteLine("Motorcycle is off");
    }
}

public class Cessna : IVehicle, IAirVehicle
{
  public int Wheels { get; set; } = 3;
  public int Doors { get; set; } = 3;
  public int PassengerCapacity { get; set; } = 113;
  public bool Winged { get; set; } = true;
  public string TransmissionType { get; set; } = "Auto";
  public double EngineVolume { get; set; } = 31.1;

  public double MaxAirSpeed { get; set; } = 309.0;

  public void Fly()
  {
    this.Start();
    Console.WriteLine("The Cessna effortlessly glides through the clouds like a gleaming god of the Sun");
  }

  public void Start()
  {
    Console.WriteLine("Yep the plane is on, don't die");
  }

  public void Stop()
  {
    Console.WriteLine(".......power failure");
  }
}


public class Program
{

    public static void Main() {

        // Build a collection of all vehicles that fly
        List<IAirVehicle> flyingThings = new List<IAirVehicle>();
        flyingThings.Add(new Cessna(){});
        flyingThings.Add(new Cessna(){});

        // With a single `foreach`, have each vehicle Fly()
        foreach (Cessna flyThing in flyingThings)
        {
            flyThing.Fly();
        }


        // Build a collection of all vehicles that operate on roads
        List<ILandVehicle> landThings = new List<ILandVehicle>();
        landThings.Add(new Motorcycle());
        landThings.Add(new Motorcycle());
        // With a single `foreach`, have each road vehicle Drive()
        foreach (Motorcycle landScooter in landThings)
        {
            landScooter.Drive();
            landScooter.Stop();
        }


        // Build a collection of all vehicles that operate on water
        List<IWaterVehicle> waterThings = new List<IWaterVehicle>();
        waterThings.Add(new JetSki());
        waterThings.Add(new JetSki());
        // With a single `foreach`, have each water vehicle Drive()
        foreach (JetSki waterThing in waterThings)
        {
            waterThing.Drive();
            waterThing.Stop();
        }
    }

}