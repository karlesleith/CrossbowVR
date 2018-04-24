using SQLite4Unity3d;

public class Score  {

    [PrimaryKey, AutoIncrement]
    public int id { get; set; }
    public int score { get; set; }

}
