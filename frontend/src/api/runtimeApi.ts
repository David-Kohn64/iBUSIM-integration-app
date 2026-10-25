export async function stopRuntime(): Promise<void> {
      const response = await fetch("/api/stop", { method: "POST" });

      if (!response.ok) {
          throw new Error(`Failed to stop runtime: ${response.status}`);
      }
  }