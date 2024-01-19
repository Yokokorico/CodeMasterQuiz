namespace Classes;

public class Joueur{
    public string Nom{
        get;
        set;        
    }
    public double Highscore{
        get;
        set;
    }

    public int Scoreactuel{
        get;
        set;
    }

    public Joueur(){
        Highscore = 0;
    }
}