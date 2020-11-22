[System.Serializable]
public class Reporter
{
    public int ID;
    public string FirstName;
    public string LastName;

    public Reporter()
    {
        this.FirstName = "Firstname";
        this.LastName = "Lastname";
    }
    public Reporter(int id, string firstName, string lastName)
    {
        this.ID = id;
        this.FirstName = firstName;
        this.LastName = lastName;
    }
}