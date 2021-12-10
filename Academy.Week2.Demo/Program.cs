using Academy.Week2.Demo;

// Demo1.DemoStruct();

// Demo1.DemoNullableTypes();

#region Delegate
Print p1 = new Print(Demo2.Print1);
Print p2 = new Print(Demo2.Print2);

p1("Ciao"); // *** Ciao ***
p2("Ciao"); // ---- Ciao ----

Print multiCast = p1;
multiCast += p2;

multiCast("Ciao a tutti!"); // chiama i due delegati da cui è composto multicast, ossia p1 e p2 (stampa prima con *** e poi con ----)

Print p3 = new Print(Demo2.Print2);
Demo2.Print3(p3); // (punto un where che prende un delegato) Come output mi aspetto ---- Ciao ancora a tutti! ----


#endregion

Demo3.DemoAnonymousTypes();