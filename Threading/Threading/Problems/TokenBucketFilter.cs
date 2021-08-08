using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    public class TokenBucketFilter
    {
        int MAX_TOKENS;
        object _lockObj = new object();
        Queue<int> tokenBucket;
        Semaphore generateTokenSem = new Semaphore(1, 1);
        Semaphore consumeTokenSem = new Semaphore(0, 1);
        public TokenBucketFilter(int MAX_TOKENS)
        {
            this.MAX_TOKENS = MAX_TOKENS;
            this.tokenBucket = new Queue<int>(MAX_TOKENS);
            //generateTokenSem.Release();
            new Thread(GenerateTokens).Start();
        }
        public void GenerateTokens()
        {
            WaitHere:
            generateTokenSem.WaitOne();
            while (tokenBucket.Count < MAX_TOKENS)
            {
                Random random = new Random();
                int code = random.Next();
                Console.WriteLine(code + " is generated");
                tokenBucket.Enqueue(code);
            }
            consumeTokenSem.Release();
            goto WaitHere;
        }

        public void getToken()
        {
            int token;
            consumeTokenSem.WaitOne();
            token = tokenBucket.Dequeue();
            generateTokenSem.Release();
            Console.WriteLine(token + " token is Accessed");
        }
        public static void Test()
        {
            TokenBucketFilter tb = new TokenBucketFilter(3);
            //tb.GenerateTokens();
            for (int i = 0; i < 5; i++)
            {
                new Thread(tb.getToken).Start();
            }
        }
    }
}
