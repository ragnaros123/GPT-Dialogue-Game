VAR chanceMinus = false

This bottle of poison you found in the chef's room, Captain, this is the exact contradiction we're talking about. #speaker: Oliver_White #portrait: explaining #layout: left 

What? How so, Detective? #speaker: Samuel_Bennett #portrait: neutral #layout: right 

Just think about it, Captain. If Chef Sullivan really were the murderer, would he have left such a blatant piece of evidence behind in his room? #speaker: Oliver_White #portrait: thinking #layout: left 

Well... #speaker: Samuel_Bennett #portrait: neutral #layout: right 

It's almost too convenient, isn't it? A chef, angry about losing his job, leaving a bottle of poison in his drawer? #speaker: Oliver_White #portrait: explaining #layout: left 

That is... a valid point, Detective. But... #speaker: Samuel_Bennett #portrait: neutral #layout: right 

Furthermore, the chef is a smart man. Would he really risk his freedom, his life, by not only murdering Mr. Jenkins but also Ms. Palmer? Two murders in such a short span... It's a heavy price to pay just to keep a job, wouldn't you agree, Captain? #speaker: Oliver_White #portrait: explaining #layout: left 

It does sound... excessive when you put it that way. But then, who...? #speaker: Samuel_Bennett #portrait: neutral #layout: right 

That's exactly what we need to figure out, Captain. #speaker: Oliver_White #portrait: explaining #layout: left 

There's also the possibility that Chef Sullivan has been framed, Captain. #speaker: Oliver_White #portrait: explaining #layout: left 
->choice
==choice==

Framed? But who... and why? #speaker: Samuel_Bennett #portrait: shocked #layout: right 
+[The steward]
The steward played a role in this. #speaker: Oliver_White #portrait: thinking #layout: left

That's absurd, Mr. White! The steward herself was a victim! #speaker: Samuel_Bennett #portrait: angry #layout: right

You've yet to provide any reason or motive for her to frame the chef. #speaker: Samuel_Bennett #portrait: angry #layout: right

Your deductions are baseless! #speaker: Samuel_Bennett #portrait: angry #layout: right

Sorry Captain. #speaker: Oliver_White #portrait: neutral #layout: left

Let me think that through again. #speaker: Oliver_White #portrait: thinking #layout: left

~chanceMinus = true
~chanceMinus = false

->choice
+[The maid]

I propose that Miss Thompson, the maid, had a part to play in it.  #speaker: Oliver_White #portrait: neutral #layout: left 
What? Now, you accuse the maid?  #speaker: Samuel_Bennett #portrait: angry #layout: right 
What possible motive could she have, Detective?  #speaker: Samuel_Bennett #portrait: angry #layout: right 
She’s worked for the family faithfully for years.  #speaker: Samuel_Bennett #portrait: angry #layout: right 
You're trying to cast suspicion on everyone, it seems.  #speaker: Samuel_Bennett #portrait: angry #layout: right 
You're right, let me think that through again.  #speaker: Oliver_White #portrait: thinking #layout: left

~chanceMinus = true
~chanceMinus = false

->choice

+[The younger son]

To answer those questions, Captain, we need to consider the origin of the poison. #speaker: Oliver_White #portrait: explaining #layout: left 

The origin? You mean, where it came from? Do you have any leads on that? #speaker: Samuel_Bennett #portrait: neutral #layout: right 

Indeed, I do. And they point towards a particular individual. The younger son of the late Mr. Jenkins - Jonathan. #speaker: Oliver_White #portrait: explaining #layout: left 

Detective, I must say I'm glad to hear someone else voice these suspicions. I've had my own doubts about young Mr. Jenkins. #speaker: Phillip_Anderson #portrait: neutral #layout: right 

Is that so, Mr. Anderson? And why is that? #speaker: Oliver_White #portrait: neutral #layout: left 

Jonathan has always been a bit of an odd one. Keeps to himself mostly. He never seemed to fit into the family, always out of place. You see, he detests the merchant family lifestyle. #speaker: Phillip_Anderson #portrait: explaining #layout: right 

Detests? Can you elaborate? #speaker: Oliver_White #portrait: neutral #layout: left 

It's more than just detest, Detective. Jonathan and his father... they've had quite the tumultuous relationship. There was an incident last year... #speaker: Phillip_Anderson #portrait: explaining #layout: right 

What sort of incident, Mr. Anderson? #speaker: Oliver_White #portrait: neutral #layout: left 

Well, they had a falling out. A public one. Jonathan lost control, began shouting at his father about the family's disregard for anyone but themselves. It was... quite the scene. #speaker: Phillip_Anderson #portrait: explaining #layout: right 

That's interesting. And how would he have gained access to the poison? #speaker: Oliver_White #portrait: thinking #layout: left 

That's just it, Detective. Jonathan has always had an interest in chemistry, ever since he was a child. His father supported this interest and as a result, he's well-versed in all sorts of substances. #speaker: Phillip_Anderson #portrait: explaining #layout: right 

And you think he would use that knowledge to...? #speaker: Oliver_White #portrait: thinking #layout: left 

It's entirely possible, Detective. Given his knowledge of chemistry, he is the only one with the ability to produce or procure something as deadly as cyanide. #speaker: Phillip_Anderson #portrait: explaining #layout: right 

His motive could be clear. But what about his method, Mr. Anderson? How would he have managed to poison his father's food? #speaker: Oliver_White #portrait: questioning #layout: left 

That's something I can't answer, Detective. But given the circumstances and his clear motive, I believe Jonathan is our prime suspect. His resentment towards his family, his knowledge of deadly substances, the turmoil with his father... it all points to him. #speaker: Phillip_Anderson #portrait: explaining #layout: right 

So, Detective White, are you now convinced of young Jonathan's involvement in this tragic event? #speaker: Phillip_Anderson #portrait: explaining #layout: right

-> DONE