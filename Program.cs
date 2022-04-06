List<NameSizePair> pairs = new List<NameSizePair>();
Console.WriteLine("Type or paste the path that you want to annalyse:");
var path = Console.ReadLine() ?? "";
var dir = new DirectoryInfo(path);
if(!dir.Exists)
{
    Console.WriteLine("Invalid path");
    return;
}
foreach (var item in dir.GetDirectories())
{
    pairs.Add(new NameSizePair
    {
        Name = item.Name,
        Size = DirSize(item)
    });
}
pairs = pairs.OrderBy(p => p.Size).ToList();
foreach(var p in pairs)
{
    Console.WriteLine($"{p.Name}, {p.Size}");
}
long DirSize(DirectoryInfo d) 
{    
    long size = 0;    
    // Add file sizes.
    FileInfo[] fis = d.GetFiles();
    foreach (FileInfo fi in fis) 
    {      
        size += fi.Length;    
    }
    // Add subdirectory sizes.
    DirectoryInfo[] dis = d.GetDirectories();
    foreach (DirectoryInfo di in dis) 
    {
        size += DirSize(di);   
    }
    return size;  
}
public class NameSizePair
{
    public string? Name { get; set; }
    public long Size { get; set; }
}