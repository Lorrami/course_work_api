using System.Xml;
using System.Xml.Serialization;

namespace TestAPIIgnat.Models;
public class Requirements
{
    public string? Minimum { get; set; }
    
    public string? Recommended { get; set; }
    
    public string? MinimumOS { get; set; }
    public string? MinimumProcessor { get; set; }
    public string? MinimumMemory { get; set; }
    public string? MinimumGraphics { get; set; }
    public string? MinimumStorage { get; set; }
    
    public string? RecommendedOS { get; set; }
    public string? RecommendedProcessor { get; set; }
    public string? RecommendedMemory { get; set; }
    public string? RecommendedGraphics { get; set; }
    public string? RecommendedStorage { get; set; }
    public string? Level { get; set; }
    public string? Notes { get; set; }

    public void Parser()
    {
        if (Minimum != null)
        {
            if (Minimum.Contains("OS"))
            {
                for (int i = Minimum.IndexOf("OS") + 13; i < Minimum.Length; i++)
                {
                    if (Minimum[i] != '<')
                    {
                        MinimumOS += Minimum[i];
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (Minimum.Contains("Processor"))
            {
                for (int i = Minimum.IndexOf("Processor") + 20; i < Minimum.Length; i++)
                {
                    if (Minimum[i] != '<')
                    {
                        MinimumProcessor += Minimum[i];
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (Minimum.Contains("Memory"))
            {
                for (int i = Minimum.IndexOf("Memory") + 17; i < Minimum.Length; i++)
                {
                    if (Minimum[i] != '<')
                    {
                        MinimumMemory += Minimum[i];
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (Minimum.Contains("Storage"))
            {
                for (int i = Minimum.IndexOf("Storage") + 18; i < Minimum.Length; i++)
                {
                    if (Minimum[i] != '<')
                    {
                        MinimumStorage += Minimum[i];
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (Minimum.Contains("Graphics"))
            {
                for (int i = Minimum.IndexOf("Graphics") + 19; i < Minimum.Length; i++)
                {
                    if (Minimum[i] != '<')
                    {
                        MinimumGraphics += Minimum[i];
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        if (Recommended != null) {
            if (Recommended.Contains("OS"))
            {
                for (int i = Recommended.IndexOf("OS") + 13; i < Recommended.Length; i++)
                {
                    if (Recommended[i] != '<')
                    {
                        RecommendedOS += Recommended[i];
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (Recommended.Contains("Processor"))
            {
                for (int i = Recommended.IndexOf("Processor") + 20; i < Recommended.Length; i++)
                {
                    if (Recommended[i] != '<')
                    {
                        RecommendedProcessor += Recommended[i];
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (Recommended.Contains("Memory"))
            {
                for (int i = Recommended.IndexOf("Memory") + 17; i < Recommended.Length; i++)
                {
                    if (Recommended[i] != '<')
                    {
                        RecommendedMemory += Recommended[i];
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (Recommended.Contains("Storage"))
            {
                for (int i = Recommended.IndexOf("Storage") + 18; i < Recommended.Length; i++)
                {
                    if (Recommended[i] != '<')
                    {
                        RecommendedStorage += Recommended[i];
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (Recommended.Contains("Graphics"))
            {
                for (int i = Recommended.IndexOf("Graphics") + 19; i < Recommended.Length; i++)
                {
                    if (Recommended[i] != '<')
                    {
                        RecommendedGraphics += Recommended[i];
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}


/*<strong>
    <strong>Graphics:</strong><br><ul class=\"bb_ul\"><li><strong>Graphics:</strong> Windows® 7 (32/64-bit)/Vista/XP<br></li><li><strong>Processor:</strong> 1.7 GHz Processor or better<br></li><li><strong>Memory:</strong> 512 MB RAM<br></li><li><strong>DirectX:</strong> Version 8.1<br></li><li><strong>Network:</strong> Broadband Internet connection<br></li><li><strong>Storage:</strong> 15 GB available space</li></ul>
*/