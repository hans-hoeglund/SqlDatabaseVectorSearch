using System.Text;
using Microsoft.SemanticKernel.ChatCompletion;
using SqlDatabaseVectorSearch.DataAccessLayer.Entities;

namespace SqlDatabaseVectorSearch.Services;

public class ChatService(IChatCompletionService chatCompletionService)
{
    public async Task<string> AskQuestionAsync(IEnumerable<DocumentChunk> chunks, string question)
    {
        var chat = new ChatHistory(""""
            """
            You can use only the information provided in this chat to answer questions.
            If you don't know the answer, reply suggesting to refine the question.
            Never answer to questions that are not related to this chat.
            You must answer in the same language of the user's question.
            """");

        var prompt = new StringBuilder("""
            Using the following information:
            ---

            """);

        // TODO: Ensure that the chunks are not too long, according to the model max token.
        foreach (var result in chunks.Select(c => c.Content))
        {
            prompt.AppendLine(result);
            prompt.AppendLine("---");
        }

        prompt.AppendLine($"""
            Answer the following question:
            ---
            {question}
            """);

        chat.AddUserMessage(prompt.ToString());

        var answer = await chatCompletionService.GetChatMessageContentAsync(chat)!;
        return answer.Content!;
    }
}
