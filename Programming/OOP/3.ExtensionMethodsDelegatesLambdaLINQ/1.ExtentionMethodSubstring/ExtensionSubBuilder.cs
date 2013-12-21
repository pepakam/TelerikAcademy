using System.Text;

public static class ExtSubBuilder
{
       public static StringBuilder SubBuilder(this StringBuilder sb, int startIndex, int lenght)
       {
           return new StringBuilder(sb.ToString(startIndex, lenght));
       }
}
