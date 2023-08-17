VAR chanceMinus = false
VAR gameOver = false
VAR openInventory = false
VAR rightItem = true

Your suspicions about Jonathan are compelling, Mr. Anderson. #speaker: Oliver_White #portrait: explaining #layout: left
But I still have an important piece of evidence that contradicts his involvement. #speaker: Oliver_White #portrait: explaining #layout: left
It's Jonathan's own statement. #speaker: Oliver_White #portrait: explaining #layout: left
He admitted that a bottle of poison was missing from his room. #speaker: Oliver_White #portrait: explaining #layout: left
If he were the murderer, why would he willingly inform us of this fact? #speaker: Oliver_White #portrait: explaining #layout: left

And what might that be, Detective? #speaker: Phillip_Anderson #portrait: neutral #layout: right

Ah, that's quite simple, Detective. #speaker: Phillip_Anderson #portrait: explaining #layout: right
He's attempting to deflect suspicion. #speaker: Phillip_Anderson #portrait: explaining #layout: right
He poisoned the food, then reported the missing poison to make it seem as though someone else had stolen it, thus trying to frame the chef. #speaker: Phillip_Anderson #portrait: explaining #layout: right

But another interpretation could be that Jonathan reported the missing poison because he had nothing to do with the murder. #speaker: Oliver_White #portrait: thinking #layout: left
If he was indeed our murderer, giving us this information could lead us right back to him - a risky move, wouldn't you say? #speaker: Oliver_White #portrait: thinking #layout: left

Perhaps, Detective. #speaker: Phillip_Anderson #portrait: neutral #layout: right
But you must admit, he's still a viable suspect. #speaker: Phillip_Anderson #portrait: neutral #layout: right

Oh, no doubt. Jonathan is indeed a suspect. #speaker: Oliver_White #portrait: neutral #layout: left

If we consider Jonathan as the murderer, there are still contradictions that are left unanswered. #speaker: Oliver_White #portrait: explaining #layout: left

What contradictions, Detective? #speaker: Phillip_Anderson #portrait: neutral #layout: right

For now, Mr. Anderson, I ask for your patience. #speaker: Oliver_White #portrait: explaining #layout: left
We must follow the deductions step by step. #speaker: Oliver_White #portrait: explaining #layout: left
Rushing might cause us to overlook crucial details. #speaker: Oliver_White #portrait: explaining #layout: left

Very well, Detective. #speaker: Phillip_Anderson #portrait: neutral #layout: right
But from what we have discussed, Jonathan and the chef are the only ones under suspicion. #speaker: Phillip_Anderson #portrait: neutral #layout: right
And given the evidence, it seems Jonathan carries the heavier weight. #speaker: Phillip_Anderson #portrait: neutral #layout: right

I see why you would think that, Mr. Anderson. #speaker: Oliver_White #portrait: explaining #layout: left
But consider this - there is one more person with a motive to kill Mr. Jenkins. #speaker: Oliver_White #portrait: explaining #layout: left

->choice
==choice==

Phillip Anderson (Assistant): Another person? Who might that be, Detective?
+[The younger son]
I believe Jonathan, the younger son, does indeed have a motive.  #speaker: Oliver_White #portrait: explaining #layout: left

Detective White, are you sure about that?  #speaker: Samuel_Bennett #portrait: neutral #layout: right

Just moments ago you were defending the young man, putting forth contradictions against his potential guilt.  #speaker: Samuel_Bennett #portrait: neutral #layout: right

How is it that you are now suggesting he might indeed have a motive?  #speaker: Samuel_Bennett #portrait: neutral #layout: right

Oh really?  #speaker: Oliver_White #portrait: shocked #layout: left

My apologies captain, let me correct myself.  #speaker: Oliver_White #portrait: neutral #layout: left

~chanceMinus = true
~chanceMinus = false

->choice
+[The maid]
What about the maid, Beatrice Thompson?  #speaker: Oliver_White #portrait: explaining #layout: left

The maid? Detective, I must object. There's no evidence that suggests her involvement in this. #speaker: Samuel_Bennett #portrait: neutral #layout: right

My apologies captain, let me correct myself.  #speaker: Oliver_White #portrait: neutral #layout: left
~chanceMinus = true
~chanceMinus = false

->choice

+[The assistant]

liver White (Detective): It is you, Mr. Anderson. You also have a motive to kill Mr. Jenkins.

Phillip Anderson (Assistant): (Laughs) Detective, you must be out of your mind. Me, murder Mr. Jenkins?

Oliver White (Detective): Yes, it's a possibility we cannot overlook.

Phillip Anderson (Assistant):  This is preposterous! I've been loyal to Mr. Jenkins for years. I've devoted my life to serving him and his family. How dare you accuse me without any substantial proof?


->presentKnot
==presentKnot==
If you have proof, present it.  #speaker: Samuel_Bennett #portrait: neutral #layout: right

~openInventory = true
~openInventory = false

This is the item I want to present. #speaker: Oliver_White #portrait: neutral #layout: left
What do you think of it? #speaker: Oliver_White #portrait: neutral #layout: left
{rightItem: ->rightKnot| -> wrongKnot} 



==wrongKnot==
Detective, I don't think that item proves your point in any way!  #speaker: Samuel_Bennett #portrait: angry #layout: right
Apologies Captain, let me try that again  #speaker: Oliver_White #portrait: neutral #layout: left
->presentKnot

==rightKnot==

->DONE



