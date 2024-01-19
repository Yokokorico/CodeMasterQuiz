using Newtonsoft.Json;
namespace Classes;

public class RecupJson{

    public static List<RacineJson> RecupJsonQuestion(string pathfile){
        try{
            using (StreamReader r = new StreamReader(pathfile))  
            {  
                string json = r.ReadToEnd();  
                List<RacineJson> myDeserializedClass = JsonConvert.DeserializeObject<List<RacineJson>>(json) ?? new List<RacineJson>();          
                return myDeserializedClass;
            } 
        }catch (Exception){
            Console.WriteLine("JSON non trouvé!");
            Console.ReadLine();
            return null;
        }  
    }
}