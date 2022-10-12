using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

var adjectives = new[]
{
    "adorable","adventurous","aggressive","agreeable","alert","alive","amused","angry","annoyed","annoying","anxious","arrogant","ashamed","attractive","average","beautiful","better","bewildered","bloody","blue","blue-eyed","blushing","bored","brainy","brave","breakable","bright","busy","calm","careful","cautious","charming","cheerful","clean","clear","clever","cloudy","clumsy","colorful","combative","comfortable","concerned","condemned","confused","cooperative","courageous","crazy","crowded","curious","cute","dangerous","dark","dead","defeated","defiant","delightful","determined","different","difficult","distinct","dizzy","doubtful","drab","dullager","easy","elated","elegant","embarrassed","enchanting","encouraging","energetic","enthusiastic","envious","evil","excited","expensive","exuberant","fair","faithful","famous","fancy","fantastic","fierce","fine","foolish","fragile","frail","frantic","friendly","frightened","funny","gentle","gifted","glamorous","gleaming","glorious","good","gorgeous","graceful","grieving","grotesque","grumpy","handsome","happy","healthy","helpful","helpless","hilarious","homeless","homely","horrible","hungry","hurt","ill","important","impossible","inexpensive","innocent","inquisitive","itchy","jealous","jittery","jolly","joyous","kind","lazy","light","lively","lonely","long","lovely","lucky","magnificent","misty","modern","motionless","muddy","mushy","mysterious","nervous","nice","nutty","obedient","odd","old-fashioned","open","outrageous","outstanding","perfect","plain","pleasant","poised","poor","powerful","precious","prickly","proud","puzzled","quaint","real","relieved","repulsive","rich","scary","selfish","shiny","shy","silly","sleepy","smiling","smoggy","sore","sparkling","splendid","spotless","stormy","strange","successful","super","talented","tame","tasty","tender","tense","terrible","thankful","thoughtful","thoughtless","tired","tough","troubled","uninterested","unusual","upset","uptight","vast","victorious","vivacious","wandering","weary","wicked","wide-eyed","wild","witty","worried","worrisome","wrong","zany","zealous"
};
var nouns = new[]
{
    "Purse","Magnifying glass","Pair of socks","Pair of binoculars","Rubber duck","Sofa","Stick","Knife","Rug","Cars","Window","Football","Sand paper","Pair of rubber gloves","Ball of yarn","Baseball hat","Purse","Blowdryer","Pair of knitting needles","Tire swing","Laser pointer","Beef","Music CD","Plush bear","Card","Plush pony","Soap","Carrot","Cat","Tennis ball","CD","Vase","Hand fan","Notebook","Hamster","Statuette","Fridge","Pop can","Bag of popcorn","Empty bottle","Fake flowers","Bonesaw","Piano","Pair of dice","Snail shell","Bottle of glue","Lion","Ladle","Can of peas","Jigsaw puzzle","Cork","Sticker book","Sticker book","Fake flowers","Playing card","Bottle of glue","Light bulb","Cellphone","Hand bag","Trash bag","Pool stick","Sponge","Doll","Vase","Keys","Toilet","Tree","Key chain","Canvas","Remote","Lion","Wine glass","Craft book","House","Whip","Cork","Chenille stick","Seat belt","Bottle of paint","Bonesaw","Novel","Plush bear","Can of beans","Candy bar","Tire swing","Bookmark","Lion","Bottle cap","Chapter book","Fish","Checkbook","Hair ribbon","Check book","Sword","Hair ribbon","Bangle bracelet","Soda can","Chenille stick","Trucks","Sandal"
};

app.MapGet("/names", () =>
{
    var adjectiveId = Random.Shared.Next(adjectives.Length);
    var nounId = Random.Shared.Next(nouns.Length);
    var adjective = adjectives[adjectiveId];
    var noun = nouns[Random.Shared.Next(nounId)];
    var result = new Name($"{adjectiveId}-{nounId}", $"{adjective} {adjective}".ToLower());
    return Results.Json(result);
})
.WithName("GetNames");

app.Run();

public class Name {
    public string id { get;set;}
    public string name { get;set;}

    public Name(string id, string name)
    {
        this.id = id;
        this.name = name;
    }
}