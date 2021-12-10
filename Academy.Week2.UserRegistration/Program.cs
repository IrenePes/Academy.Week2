// Quando l'utente si registra a un sito viene inviato un sms o una mail per verificare la registrazione

// creo un' istanza di registrazione 

using Academy.Week2.UserRegistration;

Registration r1 = new Registration(Registration.NotifyUserByEmail);

r1.CheckFields("m.rossi@bo.it");

Registration r2 = new Registration(Registration.NotifyUserBySMS);

r2.CheckFields("+393347779999");

r2.Welcome('F', "Maria", Registration.DaiBenvenuto);

r1.Welcome('M', "Mario", Registration.SayWelcome);

User user1 = new User();
user1.UserName = "MarioR";
user1.Age = 30;

r1.ShowContents(user1, user1.IsAdult);

Publisher publisher1 = new Publisher("Youtube");
publisher1.Publish();

user1.Subscribe(publisher1);

publisher1.Publish();

User user2 = new User();
user2.UserName = "SaraB";

user2.Subscribe(publisher1);

publisher1.Publish();
