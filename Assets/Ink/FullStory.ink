VAR octopusplural = "octopi"
VAR turtletype = ""

-> OctopusFirstVisit
=== OctopusFirstVisit ===
= Entry
* [Open your eyes]
    As you open your eyes, you see the oceans around you.
- There are rocks and plants. And another turtle!
* [Swim towards the rocks] You head for the rocks <>
* [Swim towards the plants] You head for the plants <>
* [Swim towards the turtle]  You head for the turtle <>

- but instead bump painfully into something hard.

As you shake your head, you see your fellow turtle do the same. ->Reflection

= Reflection
* We're so in sync!
    Perhaps. Or? -> Reflection
* It's my reflection...

- With a heavy heart, you realise that you've woken up trapped. Locked in a glass box not much bigger than yourself.

-> ANoise

= ANoise
You hear a noise from the other side of the tank.
* [Investigate]
    You swim over to the origin of the noise -> InvestigateNoise
* [Hide]
    You hide inside your shell. -> HideFromNoise
    
= InvestigateNoise
    In the corner of the tank, the noise is loudest. It's a scraping sound, and it's coming from the lid!
    
    It starts to move, and a creature appears in the gap.
    
    "Hah, you are an inquisitive one."
    
    -> OctopusAppears
    
= HideFromNoise
    You take comfort in the quiet and dark.
    
    * [...]
    
    -
    * [It occcurs to you that this probably doesn't count as hiding.]
    -
    * [. . .]
    
    "Come out little friend, you're safe."
    
    You slowly peek out from your home.
    
    -> OctopusAppears

=OctopusAppears
    Before you is an octopus, leaning into the tank.
    
    He looks <>
    
    * [Scared] "You look scared."
        The octopus grins.
        "Me? No, little friend. If anything you should be the one afraid, having an uninvited guest barge into your tank. But you needn't worry; I've come to help."
    * [Hungry] "You look hungry."
        The octopus laughs.
        "Well perhaps a little. But it's not like I can eat you, little friend. With a shell like that, I wouldn't stand a chance."
    * [At ease]
        The octopus laughs.
        "You're not wrong, little friend. I don't carry many burdens. But you? You've been trapped. You must be glad I came."
    - * "What are you doing here?"
        The octopus seems surprised to be asked. He takes a moment.
        "I'm here to free you, of course! To see a turtle trapped like this, I couldn't abide it. So I've come to let you go."
    -
    * "Wow, thanks!"[], you exclaim.
        
    * "You're freeing me because I'm a turtle?"[], you ask.
        "Such a majestic creature, it would be wrong to have you bumping up against glass all your days.", he replies.
        * * "But how did you know I was a turtle?"[], you ask. "You only saw me once you opened the tank."
            The octopus seems irritated.
            "A lot of questions for someone who has just been gifted their freedom. I wouldn't want to have to leave you here."
            You decide against further probing.
        * * "We are very majestic."[], you agree, proudly nodding your head.
            "Yes, indeed."
    * "Where are we?"[], you ask.
        "An aquarium, if you've ever heard of such a thing. Hundreds, maybe thousands of creatures like you, packed into little boxes so that they can be oggled at."
        
        He gestures grandly with one of his tentacles.
        
        "It's no life - but consider yourself one of the lucky ones! I can free you, and you have the land legs to make it back to the sea. The others would give anything for that chance.
        * * "That is lucky."[], you say, nodding. "I'm glad you found me."
            The octopus nods, sagely.
            Your freedom will be thanks enough.
        * * "Like me? You mean like us?"
            The octupus is confused. "Excuse me?"
            "You said thousands of creatures like me. But you're trapped as well, aren't you? Creatures like us."
            "Ah well of course." he replies, a little nervous. "But as you can see I'm freer than most. Hard to keep us octopi locked away you know!"
            * * *  [Say nothing]
            * * * "You know 'octopi' is the wrong plural, right? It's a popular misconception."
                "I really don't think it ma-"
            * * * * "Plurals ending in 'i' are only for words with Latin roots. But octopus comes from the Greek 'oktṓ' meaning eight, and 'poús' meaning foot.
                    The octopus seems profoundly unamused.
            - - - -
            * * * * "So the correct pluralisation would be octopodes if you're going with the Greek or octopuses if you wished, instead, to conform to standard linguistic style."
                    The octopus does not reply immediately.
                    "The case for your freedom grows stronger by the moment."
                    ~ octopusplural = "octopuses"
            
    - The octopus gestures beyond the tank, to the ground below.
    "There is a drain in the floor here. It case of spillages or water changes in the tanks, it drains straight to the coast. It's latched shut, but we {octopusplural} are awfully dextrous. You'll be free again."
    * "I have some questions first."
        "That's fine, little friend.", the octopus replies. "But let's be quick. Time is of the essence."
        -> FirstOctoQuestions
    * "I'm ready, let's go!"[], you say, brimming with excitement.
        -> FirstExit

=FirstOctoQuestions
    * "Aren't you going to leave too?"
        "Ah I wondered if you'd ask, little friend."
        He shakes his head.
        "But I have been here a long time, and I don't think I could go back to the outside. No, your freedom is enough." -> FirstOctoQuestions
    * "Have you freed other creatures before me?"
        He pauses to think.
        "I have. But it's been such a long time, I can hardly even rememeber them."
        He laughs.
        "They seemed so important at the time, too. It's funny what you forget."
         -> FirstOctoQuestions
    * "Do we have have to leave now?["] This is all very new to me, I'd like to soak it in before I go."
        He raises his octo-eyebrows.
        "There aren't many who want to sightsee in their prison."
        "But your odd wishes aside, we do have to move quickly. This is an acclimatisation tank. They're keeping you here until they can move you into the main tank, and if you end up in there... Well, that's the end for you. You'll never be free."
        * * I see. Time is of the essence.
            "Exactly"
            -> FirstOctoQuestions
        * * "Why can't I escape from the main tank too?"[], you ask.
            He scoffs.
            "It's their crown jewel. It's monitored far more closely than these little enclosures. All sorts of systems are in place to keep you there."
            * * * "Whoa, that does sound scary. We'd better be quick."
                "Exactly, I'm glad you're sensible.
            * * * "What kinds of systems?"
                "I don't know them all - I don't go in the main tank. But they have fracture monitoring on the glass, sensors above the tank to check if creatures break out, that sort of thing. It's maximum security.
                * * * * "I see."
                    "It's no good there, little friend." He shakes his head.
                * * * * "I bet I could break out. I've already broken out of this tank. I'm an escape turtle!"
                    The octopus rolls his eyes.
                    "You are not an escape turtle, little friend. I broke you out of here. You are a lucky turtle.
                    * * * * * He's wrong, I'm an escape turtle.
                        ~ turtletype = "escape"
                    * * * * * He's right, I'm a lucky turtle.
                        ~ turtletype = "lucky"
        - - -> FirstOctoQuestions
            
    * "That's all I wanted to ask. Let's go." -> FirstExit
    
=FirstExit
    The octopus opens the lid further, large enough for you to leave with him.
    "It is time, little friend. You'll breathe free air again soon."
    * [I'm excited]
        The excitement is palpable, this is an adventure!
    * [I'm afraid]
        The exterior of the tank represents the terrifying unknown, but you know must proceed.
    * [I'm suspicious]
        The kindness of this stranger makes you wary, but his help is nonetheless preferable to being stuck in this cage.
    -
    {turtletype == "escape": You are, indeed, the escapiest of the escape turtles.}
    {turtletype == "lucky": You are, indeed, the luckiest of the lucky turtles.}
    
The octopus leads you to the drain on the ground below.

As you get closer you see further down the corridor a huge tank filled with beautiful and varied sea life, all swimming around a central artificial coral reef. 
* "Is that the main tank?"
- "Yes, now do you see why we must leave quickly."
* [Nod] 
    -> lonely_escape
    
* [Suggest saving them] 
    -> together_escape
=== together_escape
// I've added branch names incase we actually want to make this branch off

"We can't leave the others behind! This is no life to live!"

"They are only fish. They cannot break out like you, they need water to breathe."

*   "We can find a way!"
    "You are so innocent little turtle friend."
*   [Surely you are clever enough to come up with something?] "Surely you are clever enough to come up with something?"
    "Oh of course, but there are dangers here that you do not understand."
- -> innocence
    
= innocence

*   "What do you mean?"
    "Fish keep mysteriously disappearing, I would not like to see you .... become a snack."
    -> mantis_snacks
    
= mantis_snacks 
    
*   "Do you know who it is?"
    "... I .... have no clue. However, there is a rumour that the mantis shrimp in the corner of the tank has not been the friendliest in his past."
*   "Do you know what is causing this?"
    "Not what, but there could be a who."
    "The mantis shrimp has, let's say, a suspicious aura about him."
- -> mantis_bad
    
= mantis_bad

*   "I could investigate the mantis shrimp."
    The Octopus looks at you with a smile. 
    "If you are brave enough."
*   "I'm sure if we get everyone on board, the mantis shrimp cannot hurt us all."
    The Octopus looks at you curiously.
    "If you are sure you can convince everyone."
-
*   ["I am!"] "I am!" you declare enthusiastically. 
    -> exit_tank_stage_left
    
= exit_tank_stage_left

    The Octopus pauses briefly and then stares at you. 

    "I think you are making a mistake, but I will help you as I like your determination. It's adorable."
    
    The Octopus grins widely then points down the hallway.
    
 -  "The tank is down there, good luck."
    
*   [Follow the way the Octopus points]
        -> END //put the next chapter link here. 
    
=== lonely_escape
= swirling_drain
The water rushes around you, pulling you down into the darkness, where you're suddenly plunged into the sea. It's cold but it's freedom.
* [Turn back]
    The aquarium looms over the pier. It's so much bigger than you ever thought possible.
    Your mind wanders to the people you left behind.
    You turn and leave.
    -> END
* [Keep swimming]
    You swim deeper into the ocean.
    -> END
-> END
    
->END