# AnaphoraCore
An open source web based anaphora resolution tool build in asp.net core.

-What is AnaphoraCore?
AnaphoraCore is an online anaphora/coreference resolution solution.
It doesn't require any tagging, as it can analyze the sentences on its own.
It uses a machine learning technique called support vector machine, Microsoft Linguistics API, and asp.net Core MVC technologies.
AnaphoraCore is an open source program licenced under GNU Public Licence v4. Its source code can be accessed here.
Bibliography and digital sources for this work
To tackle the problem I have studied several publications. Note that I haven't used any of the algorithms that are presented in these articles. This is one of the reasons why I am making this project open source:

-Anaphora resolution in unrestricted texts with partial parsing In Proceedings of the 36th Annual Meeting of the Association for Computational Linguistics and 17th International Conference on Computational Linguistics (COLING-ACL'98), 385-391 Montreal (Canada). Ferrández et al.1999 Ferrández, A., Palomar, M., Moreno, L. 1999.
-Anaphora resolution: a multi-strategy approach In Proceedings of 12th International Conference on Computational Linguistics (COLING'88), 96-101 Budapest (Hungary). Carletta et al.1997 Carletta, J., et al. 1997.
-Easy-first Coreference Resolution - Veselin Stoyanov, Jason Eisner (Unpublished, can be accessed here)

-Version notes for v0.1
The project is pushed to GitHub.
The algorithm for detecting and parsing clauses is in effect.
Algorithm explanations have been added to the source code functions.

-Planned Updates
I will apply to Microsoft's Cognitive Services Showcase.
Machine learning algorithm will be further developed.
The sentences will be recorded and human revision will be asked after each analysis.
The user login will be implemented for statistics & machine learning algorithm.
Gender API will be added to improve name recognition.

-Known Bugs
The system cannot properly distinguish a female and a male.
The system performs poorly (or it doesn't work at all) when the pronoun refers to a non-person noun. This will be fixed.

-Special Thanks
Special thanks to Claire Peeters and Mariana Vignoli for helping me test the application and special thanks to Dr. Cristóbal Lozano for laying the foundations of this work.

-Contact and Donations
AnaphoraCore is a free-to-use and open source application. I have some further plans to develop it of which you can check at Planned Updates section. However development takes time and server management which costs money, and I am a graduate student with low income. Would you like to help me develop it further? Donations will surely motivate me in developing AnaphoraCore and other linguistic tools!
