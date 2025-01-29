namespace GooniesScouting.Business.Model
{
    public class FtcTeam
    {
        public string Name { get; set; }
        public string Number { get; set; }

        public FtcTeam()
        {

        }

        public FtcTeam(string name, string number)
        {
            Name = name;
            Number = number;
        }
    }
}