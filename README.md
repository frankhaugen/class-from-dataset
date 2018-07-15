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
	public string Id { get; set; }
	public string Hip { get; set; }
	public string Hd { get; set; }
	public string Hr { get; set; }
	public string Gl { get; set; }
	public string Bf { get; set; }
	public string Proper { get; set; }
	public string Ra { get; set; }
	public string Dec { get; set; }
	public string Dist { get; set; }
	public string Pmra { get; set; }
	public string Pmdec { get; set; }
	public string Rv { get; set; }
	public string Mag { get; set; }
	public string Absmag { get; set; }
	public string Spect { get; set; }
	public string Ci { get; set; }
	public string X { get; set; }
	public string Y { get; set; }
	public string Z { get; set; }
	public string Vx { get; set; }
	public string Vy { get; set; }
	public string Vz { get; set; }
	public string Rarad { get; set; }
	public string Decrad { get; set; }
	public string Pmrarad { get; set; }
	public string Pmdecrad { get; set; }
	public string Bayer { get; set; }
	public string Flam { get; set; }
	public string Con { get; set; }
	public string Comp { get; set; }
	public string Comp_primary { get; set; }
	public string Base_ { get; set; }
	public string Lum { get; set; }
	public string Var_ { get; set; }
	public string Var_min { get; set; }
	public string Var_max { get; set; }
}

```