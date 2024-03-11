Zywave Technical Assignment 
Through Joaquin Feliciano of PMConsulting

DateTime Recieved: March 11, 2024 08;15 GMT +8


High-level overview on how to possibly integrate this solution into an email messaging system:

1.Reception of Emails: Have a service that recieves every email on the organization, and store these emails in a temporary email storage. 

2. Email Processing: The system retrieves the email from the temporary storage area and begins to parse the email to extract the text content of the email and store it to a json file. In this solution the json file is name emailConents.json.

3. Run the Checking: By implementing this solution with the email messaging system, it will run a check through CensorEmail function along with the list of classified words. The funtion then will return a flag.

4. Actions after checking: If the flag returned is true; the system will take appropriate actions based on the policies of the organization. It also is possible to have another storage for the flagged emails for futher analysis or processes; that might be used to extract valuable information to prevent the circulation of classified information. If the flag is false, then it is forwarded to the user's inbox.

5. Notification: Depending on the orgnization's policies, the system could potentially notify the user that there is an email or emails that were flagged to have classified information, or the organtization could just block it entirely with out notifiying the user.


Psuedo code representation of the steps above. 
function ProcessEmail(email):
    emailText = ExtractText(email)
    classifiedWords = GetClassifiedWords()
    flag, censoredText = CensorEmail(classifiedWords, emailText)

    if flag is true:
        ClassifiedEmailHandler(email, censoredText)
    else:
        ForwardEmailToUser(email)

function ClassifiedEmailHandler(email, censoredText):
"Take action based on organization's policies."