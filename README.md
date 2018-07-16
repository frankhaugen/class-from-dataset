## class-from-dataset
A simple tool to use a dataset, (e.g. CSV), to generate a .class file with properties based on the header.

The idea is that sometimes you have data with so many columns that it takes way to long to create it manually.

This tool creates the class and a starting point of properties, so the programmer can start working with the data imediatly  
### Basic functionality
Feed tha program with a dataset it recognizes with headers and some data, (min. 5 lines of data), and it will create a class after doing a "best guess" for which datatype it should use for the diffrent columns, (if it's less than 60% certain, it will deem it a string by default)

It also checks the method names for "illigal words", (like "var"), and uppercases the first letter
### Testing Dataset
While testing, this program uses an astronomical dataset, because it has coloumns of varying types of data.

### Sample input (headers)
>id,hip,hd,hr,gl,bf,proper,ra,dec,dist,pmra,pmdec,rv,mag,absmag,spect,ci,x,y,z,vx,vy,vz,rarad,decrad,pmrarad,pmdecrad,bayer,flam,con,comp,comp_primary,base,lum,var,var_min,var_max

### Sample output
```csharp
class 
{
	public int Id { get; set; }
	public string Hip { get; set; }
	public string Hd { get; set; }
	public string Hr { get; set; }
	public string Gl { get; set; }
	public string Bf { get; set; }
	public string Proper { get; set; }
	public decimal Ra { get; set; }
	public decimal Dec { get; set; }
	public decimal Dist { get; set; }
	public decimal Pmra { get; set; }
	public decimal Pmdec { get; set; }
	public decimal Rv { get; set; }
	public decimal Mag { get; set; }
	public DateTime Absmag { get; set; }
	public string Spect { get; set; }
	public decimal Ci { get; set; }
	public decimal X { get; set; }
	public decimal Y { get; set; }
	public decimal Z { get; set; }
	public decimal Vx { get; set; }
	public decimal Vy { get; set; }
	public decimal Vz { get; set; }
	public int Rarad { get; set; }
	public int Decrad { get; set; }
	public int Pmrarad { get; set; }
	public int Pmdecrad { get; set; }
	public string Bayer { get; set; }
	public string Flam { get; set; }
	public string Con { get; set; }
	public int Comp { get; set; }
	public int Comp_primary { get; set; }
	public string Base_ { get; set; }
	public int Lum { get; set; }
	public string Var_ { get; set; }
	public string Var_min { get; set; }
	public string Var_max { get; set; }
}
```