VAR gameOver = false
VAR openInventory = false
VAR rightItem = true


I must decide carefully  #speaker: Oliver_White #portrait: thinking #layout: left
+ [Yes, I am convinced]
My apologies, Captain, if my questioning seemed harsh.  #speaker: Oliver_White #portrait: explaining #layout: left
I only seek to leave no stone unturned.  #speaker: Oliver_White #portrait: explaining #layout: left
I understand, Detective.  #speaker: Samuel_Bennett #portrait: neutral #layout: right
In the meantime, Chef Sullivan will be held in confinement.  #speaker: Samuel_Bennett #portrait: neutral #layout: right
Once we reach the shore, she'll be handed over to the authorities.  #speaker: Samuel_Bennett #portrait: neutral #layout: right
Well done, Captain Bennett.  #speaker: Phillip_Anderson #portrait: happy #layout: left
We have faith in your leadership.  #speaker: Phillip_Anderson #portrait: happy #layout: left
We appreciate your efforts, Detective White, and yours too, Captain Bennett.  #speaker: Arthur_Jenkins #portrait: grateful #layout: right
We're grateful for the swift actions you've both taken.  #speaker: Mrs._Jenkins #portrait: grateful #layout: right
Our hearts are with you in these challenging times.  #speaker: Mrs._Jenkins #portrait: grateful #layout: right
~gameOver = true

game Over

+ [No, I am not convinced]
Of course not, Captain!  #speaker: Oliver_White #portrait: neutral #layout: left
What do you mean, Detective?  #speaker: Samuel_Bennett #portrait: neutral #layout: right
There's a crucial contradiction in our findings that we've overlooked.  #speaker: Oliver_White #portrait: explaining #layout: left
Contradiction? What are you referring to, Detective?  #speaker: Samuel_Bennett #portrait: neutral #layout: right
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
What is that?  #speaker: Samuel_Bennett #portrait: angry #layout: right
->DONE