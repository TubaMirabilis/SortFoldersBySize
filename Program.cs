List<NameSizePair> pairs = new List<NameSizePair>();
foreach (var item in new DirectoryInfo(@"E:\X-Plane 11\Custom Scenery").GetDirectories())
{
    pairs.Add(new NameSizePair
    {
        Name = item.Name,
        Size = DirSize(item)
    });
}
var ordered = pairs.OrderBy(p => p.Size);
foreach(var p in ordered)
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