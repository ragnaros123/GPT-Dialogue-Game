VAR chanceMinus = false
VAR gameOver = false
VAR openInventory = false
VAR rightItem = true


Mr. Anderson. I present to you this letter, provided to me by Mr. Jenkins' elder son, Arthur.  #speaker: Oliver_White #portrait: explaining #layout: left

I... I... I've never seen that before.  #speaker: Phillip_Anderson #portrait: shocked #layout: right

Are you sure, Mr. Anderson? You don't recognize the handwriting?  #speaker: Oliver_White #portrait: neutral #layout: left

I told you, I don't know where that came from!  #speaker: Phillip_Anderson #portrait: angry #layout: right

That's odd, because it bears your initials at the bottom. 'P.A.' Could that stand for Phillip Anderson?  #speaker: Oliver_White #portrait: thinking #layout: left

That could be anyone's initials! They are not exclusive to me.  #speaker: Phillip_Anderson #portrait: angry #layout: right

You're correct, Mr. Anderson. But what's peculiar is that the handwriting on this letter matches the documents you've written for Mr. Jenkins, the ones I've inspected.  #speaker: Oliver_White #portrait: explaining #layout: left

This is an outrage! A disgraceful attempt to smear my reputation! How does this letter even link me to the crime? Do you think I am that foolish to leave such a blatant trace?  #speaker: Phillip_Anderson #portrait: angry #layout: right

This letter suggests an unusual relationship between you, Mr. Anderson, and Mrs. Jenkins, the wife of our deceased merchant.  #speaker: Oliver_White #portrait: explaining #layout: left

This is slander! I would never betray Mr. Jenkins in such a manner. You have no proof!  #speaker: Phillip_Anderson #portrait: angry #layout: right

Mr. Jenkins' elder son, Arthur, has shared his suspicion of a possible affair between you and Mrs. Jenkins. And as a detective, I can't ignore such a claim.  #speaker: Oliver_White #portrait: explaining #layout: left

It's preposterous! Arthur has always been an overly suspicious fool!  #speaker: Phillip_Anderson #portrait: angry #layout: right

Is there anyone here who can provide any evidence about the alleged relationship between Mr. Anderson and Mrs. Jenkins?  #speaker: Oliver_White #portrait: neutral #layout: left

I don't usually pry into other people's business, but I have to say, there have been times when their relationship seemed...unusual. They were often seen together, even when my father was not present.  #speaker: Jonathan_Jenkins #portrait: explaining #layout: right

I'm sorry, Mr. Anderson, but it's true. I've once walked in on you and Mrs. Jenkins...kissing. I didn't mean to spy, it just...happened.  #speaker: Beatrice_Thompson #portrait: sad #layout: right

This...this is a conspiracy against me! I demand justice!  #speaker: Phillip_Anderson #portrait: angry #layout: right

This is ludicrous! You're stretching assumptions too far, detective. An affair, even if it were true, doesn't prove Phillip has any murderous intentions.  #speaker: Mrs._Jenkins #portrait: angry #layout: right

Mrs. Jenkins, I respect your defense, but consider this: if the merchant were out of the picture, wouldn't Mr. Anderson gain significant control over the merchant's wealth? It's not unheard of, a man seducing a rich man's wife for financial gain...  #speaker: Oliver_White #portrait: explaining #layout: left

This is a preposterous accusation! I was not even near the merchant last night! I have witnesses!  #speaker: Phillip_Anderson #portrait: angry #layout: right

Indeed, Mr. Anderson. Witnesses. I am aware of your supposed alibi, but there's a part of it that could potentially be false.  #speaker: Oliver_White #portrait: thinking #layout: left


->choice
==choice==

And who would that be? My witness is impeccable! #speaker: Phillip_Anderson #portrait: angry #layout: right


+[The younger son]

I was led to believe that Jonathan was vouching for your whereabouts at the time of the murder, but...  #speaker: Oliver_White #portrait: explaining #layout: left
What are you talking about?  #speaker: Phillip_Anderson #portrait: shocked #layout: right
Jonathan never said anything like that!  #speaker: Phillip_Anderson #portrait: angry #layout: right
Is that so?  #speaker: Oliver_White #portrait: thinking #layout: left
I must have been mistaken.  #speaker: Oliver_White #portrait: sad #layout: left
It seems we must rely on other evidences then.  #speaker: Oliver_White #portrait: explaining #layout: left


~chanceMinus = true
~chanceMinus = false

->choice
+[The captain]
Mr. Anderson, you claim to have a solid alibi. #speaker: Oliver_White #portrait: neutral #layout: left
However, what if I were to tell you that Captain Reynolds himself could be providing a false witness? #speaker: Oliver_White #portrait: explaining #layout: left
What?! That's a lie! #speaker: Phillip_Anderson #portrait: shocked #layout: right
I never saw Captain Reynolds after I left the bridge. #speaker: Phillip_Anderson #portrait: explaining #layout: right
I have no other business with him. #speaker: Phillip_Anderson #portrait: explaining #layout: right
I suppose you are right. #speaker: Oliver_White #portrait: thinking #layout: left
Give me a minute to think again. #speaker: Oliver_White #portrait: thinking #layout: left


~chanceMinus = true
~chanceMinus = false

->choice

+[The wife]
It's Mrs. Jenkins. Her testament might be compromised.  #speaker: Oliver_White #portrait: neutral #layout: left

You dare to accuse...  #speaker: Phillip_Anderson #portrait: angry #layout: right

If we consider the fact that you were in an affair with Mrs. Jenkins, it becomes plausible that she could've assisted you in the crime.  #speaker: Oliver_White #portrait: explaining #layout: left

You see, Mr. Anderson, it's all about relationships, and power dynamics...  #speaker: Oliver_White #portrait: explaining #layout: left

You can't just weave stories, detective!  #speaker: Phillip_Anderson #portrait: angry #layout: right

Where's your proof that I murdered the merchant?  #speaker: Phillip_Anderson #portrait: angry #layout: right

Mr. Anderson, you say you were busy with business in the merchant's room.  #speaker: Oliver_White #portrait: neutral #layout: left

But Miss Jenkins, the maid, attests that she never saw you there when she brought in the merchant's dinner.  #speaker: Oliver_White #portrait: neutral #layout: left

So, the maid now determines where I was and wasn't?  #speaker: Phillip_Anderson #portrait: angry #layout: right

Perhaps she was too busy with her tasks to notice me.  #speaker: Phillip_Anderson #portrait: angry #layout: right

Maybe, but it raises a question.  #speaker: Oliver_White #portrait: thinking #layout: left

Both you and Mrs. Jenkins testified that you were in Mr. Jenkins' room, busy with some dealings, but you're nowhere to be seen there.  #speaker: Oliver_White #portrait: thinking #layout: left

Can you explain this discrepancy, Mr. Anderson?  #speaker: Oliver_White #portrait: thinking #layout: left

I don't have to explain anything to you!  #speaker: Phillip_Anderson #portrait: angry #layout: right

You are twisting the facts!  #speaker: Phillip_Anderson #portrait: angry #layout: right

Then help me untwist them, Mr. Anderson.  #speaker: Oliver_White #portrait: neutral #layout: left

Where were you, really, when the merchant was having his dinner?  #speaker: Oliver_White #portrait: neutral #layout: left

It's none of your business!  #speaker: Phillip_Anderson #portrait: angry #layout: right

I was doing what I was hired for - ensuring Mr. Jenkins' business affairs were in order!  #speaker: Phillip_Anderson #portrait: angry #layout: right

Mr. Anderson, I believe there's one final contradiction that we've yet to address.  #speaker: Oliver_White #portrait: neutral #layout: left

Oh, and what might that be?  #speaker: Phillip_Anderson #portrait: neutral #layout: right


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


